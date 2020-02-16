using Hotsapp.Data.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotsapp.Data.Model;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.IO;

namespace Hotsapp.Connector.Services
{
    public class ServiceUpdater : IHostedService, IDisposable
    {
        PhoneService _phoneService;
        NumberManager _numberManager;
        private Timer _timer;
        private bool updateRunning = false;
        private IHostingEnvironment _hostingEnvironment;

        public ServiceUpdater(PhoneService phoneService, NumberManager numberManager, IHostingEnvironment hostingEnvironment)
        {
            _phoneService = phoneService;
            _numberManager = numberManager;
            _hostingEnvironment = hostingEnvironment;
        }

        public void OnMessageReceived(object sender, Data.MessageReceived mr)
        {
            using (var context = DataFactory.GetContext())
            {
                var number = context.VirtualNumber.SingleOrDefault(n => n.Number == _numberManager.currentFlowId);
                var message = new Message()
                {
                    Content = mr.Message,
                    ExternalNumber = mr.Number,
                    InternalNumber = _numberManager.currentFlowId,
                    DateTimeUtc = DateTime.UtcNow,
                    IsInternal = false,
                    UserId = number.OwnerId
                };
                context.Message.Add(message);
                context.SaveChanges();
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Starting");
            updateRunning = false;
            _numberManager.currentFlow = null;
            _numberManager.currentFlowId = null;
            while (true)
            {
                if (cancellationToken.IsCancellationRequested)
                    return Task.CompletedTask;
                _numberManager.TryGetFlow().Wait();

                if (_numberManager.currentFlowId != null)
                {
                    using(var ctx = DataFactory.GetContext())
                    {
                        var flow = ctx.ConnectionFlow.Where(f => f.Id == Guid.Parse(_numberManager.currentFlowId)).SingleOrDefault();
                        if((DateTime.UtcNow - flow.CreateDateUtc).TotalMinutes > 5)
                        {
                            flow.IsActive = false;
                            flow.IsSuccess = false;
                            flow.ErrorMessage = "Tempo Excedido";
                            _numberManager.currentFlowId = null;
                            ctx.SaveChanges();
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                Console.WriteLine("Waiting for new Connection Flow...");
                Task.Delay(1000).Wait();
            }

            UpdateTask(null);
            _phoneService.OnMessageReceived += OnMessageReceived;

            var success = _phoneService.SendCode().Result;

            _timer = new Timer(UpdateTask, null, TimeSpan.Zero,
                TimeSpan.FromMilliseconds(500));
            return Task.CompletedTask;
        }

        private void UpdateTask(object state)
        {
            if (updateRunning)
                return;
            updateRunning = true;
            Console.WriteLine("UPDATE TASK RUN");
            try
            {
                using (var ctx = DataFactory.GetContext())
                {
                    var flow = ctx.ConnectionFlow.Where(c => c.Id == Guid.Parse(_numberManager.currentFlowId)).SingleOrDefault();
                    _numberManager.currentFlow = flow;
                    if(flow.ConfirmCode!= null)
                    {
                        Console.WriteLine("Validating confirmation code");
                        var success = _phoneService.ConfirmCode().Result;
                        if (success)
                        {
                            Console.WriteLine("Code is valid!");
                            Console.WriteLine("Saving number data");
                            flow.IsActive = false;
                            flow.IsSuccess = true;

                            var vn = ctx.VirtualNumber.Where(n => n.Number == flow.PhoneNumber).SingleOrDefault();
                            bool isNew = vn == null;
                            if(isNew)
                                vn = new VirtualNumber();

                            vn.Number = flow.PhoneNumber;
                            vn.OwnerId = flow.UserId;
                            vn.OwnerId = flow.UserId;
                            vn.Error = null;

                            if (isNew)
                                ctx.VirtualNumber.Add(vn);
                            else
                                ctx.VirtualNumber.Update(vn);

                            ctx.SaveChanges();

                            _phoneService.Stop();
                            try
                            {
                                if ((bool)_numberManager.currentFlow.IsSuccess)
                                    _numberManager.SaveNumber().Wait();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("Confirmation error");
                            flow.IsActive = false;
                            flow.ErrorMessage = "Falha na confirmação";
                            flow.IsSuccess = false;
                            ctx.SaveChanges();
                        }
                    }
                }

                if ((bool)_numberManager.currentFlow.IsActive && (DateTime.UtcNow - _numberManager.currentFlow.CreateDateUtc).TotalMinutes > 5)
                {
                    using (var ctx = DataFactory.GetContext())
                    {
                        var flow = ctx.ConnectionFlow.Where(c => c.Id == Guid.Parse(_numberManager.currentFlowId)).SingleOrDefault();
                        flow.IsActive = false;
                        flow.ErrorMessage = "Tempo excedido";
                        ctx.SaveChanges();
                    }
                }

                if (_numberManager.ShouldStop().Result)
                {
                    StopAsync(new CancellationToken()).Wait();
                    Task.Run(() =>
                    {
                        Task.Delay(3000).Wait();
                        StartAsync(new CancellationToken());
                    });

                    return;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

            updateRunning = false;
        }


        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Timed Background Service is stopping.");


            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
