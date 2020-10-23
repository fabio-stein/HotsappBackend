using Hotsapp.Data.Model;
using Hotsapp.Data.Util;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WaClient.Connector;
using WaClient.Worker.Data;

namespace WaClient.Worker.Worker
{
    public class PhoneWorker
    {
        private ILogger _log = Log.Logger.ForContext<PhoneWorker>();
        private CancellationToken _ct;
        private CancellationTokenSource _cts;
        private Task workerTask;
        private IWaConnector client;
        private PhoneRepository _repository;

        private WaPhone phoneInfo;

        public PhoneWorker(PhoneRepository repository)
        {
            _repository = repository;
        }

        public void Start(WaPhone p, CancellationToken ct)
        {
            phoneInfo = p;
            _log = _log.ForContext("phoneNumber", p.Number);
            _log.Information("Starting worker");
            _cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
            _ct = _cts.Token;

            workerTask = Task.Run(async () =>
            {
                client = new WaConnector().GetClient();
                var errorCount = 0;

                while (!_ct.IsCancellationRequested)
                {
                    try
                    {
                        var status = await client.GetStatus();
                        if (!status.initialized)
                        {
                            _log.Information("Initializing client");
                            await client.Initialize(new Connector.Model.InitializeOptions()
                            {
                                session = phoneInfo.Session
                            });
                        }
                        if (!status.ready)
                        {
                            _log.Information("Client not ready");
                        }
                        else
                        {
                            //SEND MESSAGES
                            var toSend = (await _repository.GetPendingMessages(phoneInfo.Number)).ToList();
                            var chatDict = new Dictionary<int, WaChat>();
                            for (int i = 0; i < toSend.Count; i++)
                            {
                                var msg = toSend[i];
                                WaChat chat;
                                if (chatDict.ContainsKey(msg.ChatId))
                                    chat = chatDict[msg.ChatId];
                                else
                                {
                                    using (var ctx = DataFactory.GetDataContext())
                                    {
                                        chat = await ctx.WaChat.FirstOrDefaultAsync(c => c.Id == msg.ChatId);
                                    }
                                    chatDict[msg.ChatId] = chat;
                                }

                                await client.SendMessage(new Connector.Model.SendMessageModel()
                                {
                                    user = chat.RemoteNumber,
                                    text = msg.Body
                                });
                                await _repository.SetMessageProcessed(msg.MessageId);
                            }

                            //RECEIVE MESSAGES
                            var messagesList = await client.GetMessages();
                            var userMessages = messagesList.GroupBy(m => m.id.remote).ToList();
                            userMessages.ForEach(async messages =>
                            {
                                var remote = messages.Key;
                                var log = _log.ForContext("remote", remote);
                                var listMessages = messages.ToList().OrderBy(m => m.timestamp).ToList();

                                var activeChat = await _repository.CheckActiveChat(remote);

                                if (activeChat == null)
                                {
                                    var areas = _repository.GetPhoneAreas(phoneInfo.Number).ToList();

                                    log.Information("Active chat null, creating new");
                                    var first = listMessages.First();
                                    var text = first.body.Trim();
                                    int option;
                                    if(int.TryParse(text, out option) && areas.FirstOrDefault(f => f.Id == option) != null)
                                    {
                                        log.Information("Valid Option!");
                                        //VALID
                                        activeChat = await _repository.CreateChat(phoneInfo.Number, remote, option);
                                        await client.SendMessage(new Connector.Model.SendMessageModel()
                                        {
                                            user = remote,
                                            text = "Chat iniciado!\nEm breve um atendente entrará na conversa."
                                        });
                                    }
                                    else
                                    {
                                        log.Information("Invalid Option!");
                                        //INVALID
                                        await client.SendMessage(new Connector.Model.SendMessageModel()
                                        {
                                            user = remote,
                                            text = phoneInfo.DefaultMessage
                                        });
                                    }
                                }

                                if (activeChat != null)
                                {
                                    for (int i = 0; i < listMessages.Count; i++)
                                    {
                                        var msg = listMessages[i];
                                        await _repository.InsertMessage((int)activeChat, phoneInfo.Number, msg.body, DateTime.UtcNow, false);
                                        log.Information("Message inserted");
                                    }
                                }
                            });
                        }
                    }
                    catch (Exception e)
                    {
                        errorCount++;
                        _log.Error(e, "Worker error count: {1}", errorCount);
                        if (errorCount > 10)
                        {
                            _log.Information("Ignoring errors flood (DEV MODE)");
                            try
                            {
                                await client.Stop();
                            }
                            catch (Exception x)
                            {
                                _log.Information(x, "Failed to restart");
                            }
                            /*_log.Information("TODO - Stop with error");
                            StopInternal();
                            break;*/
                        }
                        try
                        {
                            await Task.Delay(10000, _ct);
                        }
                        catch (OperationCanceledException _)
                        {
                            _log.Information("Delay skipped");
                        }
                    }

                    try
                    {
                        await Task.Delay(1000, _ct);
                    }
                    catch (OperationCanceledException _)
                    {
                        _log.Information("Delay skipped");
                    }
                }
            });
        }

        //We should not wait Stop() inside worker, waiting here may cause infinite loop
        private void StopInternal()
        {
            _log.Information("StopInternal()");
            _ = Stop();
        }

        //Should only be called from other classes
        public async Task Stop()
        {
            _log.Information("Stopping channel");
            if (!_ct.IsCancellationRequested)
                _cts.Cancel();
            if (workerTask == null)
                return;
            await Task.WhenAll(workerTask);
        }
    }
}
