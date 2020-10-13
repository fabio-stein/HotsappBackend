using Hotsapp.Data.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WaClient.Connector;

namespace WaClient.Worker
{
    public class DevService : IHostedService
    {
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var session = "";
            using (var ctx = DataFactory.GetDataContext())
            {
                var info = await ctx.WaPhone.FirstAsync();
                session = info.Session;
            }

            var client = new WaConnector().GetClient();

            _ = Task.Run(async () =>
              {
                  await Task.Delay(3000);
                  while (true)
                  {
                      try
                      {
                          await client.SendMessage(new Connector.Model.SendMessageModel()
                          {
                              user = "555599436679@c.us",
                              text = DateTime.Now.ToString()
                          });
                      }
                      catch (Exception e)
                      {
                          await Task.Delay(5000);
                          continue;
                      }
                      await Task.Delay((int)TimeSpan.FromHours(1).TotalMilliseconds);
                  }
              });

            while (true)
            {
                try
                {
                    var status = await client.GetStatus();

                    if (!status.initialized)
                    {
                        Console.WriteLine("INITIALIZING...");
                        await client.Initialize(new Connector.Model.InitializeOptions()
                        {
                            session = session
                        });
                        await Task.Delay(5000);
                    }

                    var messages = await client.GetMessages();
                    messages.ForEach(async m =>
                    {
                        await client.SendMessage(new Connector.Model.SendMessageModel()
                        {
                            user = m.id.remote,
                            text = m.body
                        });
                        Console.WriteLine($"[{m.id.remote}] {m.body}");
                    });
                }catch(Exception e)
                {
                    Log.Error(e, "Task failed");
                }
                await Task.Delay(1000);

            }

            Console.WriteLine("Hello World!");
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            
        }
    }
}
