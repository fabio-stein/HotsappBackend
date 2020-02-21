using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hotsapp.ServiceManager.Services
{
    public class ProcessManager
    {
        private Process process;
        public event EventHandler<string> OnOutputReceived;
        IHostingEnvironment _env;
        private event EventHandler OnTerminating;
        private ILogger<ProcessManager> _log;

        public ProcessManager(IHostingEnvironment env, ILogger<ProcessManager> log)
        {
            _env = env;
            _log = log;
            OnOutputReceived += (a, b) => { }; //Handler needs to have at least 1 listener
        }

        public async Task SendCommand(string command)
        {
            _log.LogInformation($"[Command] {command}");
            await process.StandardInput.WriteAsync($"{command}\n");
        }

        public void Start()
        {
            _log.LogInformation("Starting new process");
            process = new Process();
            var startInfo = new ProcessStartInfo();
            
            if(_env.IsDevelopment())
                startInfo.FileName = "bash";
            else
                startInfo.FileName = "/bin/bash";
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.StandardOutputEncoding = Encoding.UTF8;

            process.StartInfo = startInfo;

            process.Start();

            _ = ReadOutput(process.StandardOutput);
            _ = ReadOutput(process.StandardError);
        }

        public void Stop()
        {
            ForceKill();
        }

        private void ForceKill()
        {
            _log.LogInformation("Killing process");
            try
            {
                process.Kill();
                _log.LogInformation("Process stopped");
            }catch(Exception e)
            {
                _log.LogError(e, "Error killing Yowsup");
            }
        }

        private async Task ReadOutput(StreamReader sr)
        {
            try
            {
                while (true)
                {
                    var line = await sr.ReadLineAsync();
                    _log.LogInformation("[Client] {0}", line);
                    OnOutputReceived.Invoke(this, line);
                }
            }catch(Exception e)
            {
                _log.LogError(e, "Error reading process output");
            }
        }

        public async Task<string> WaitOutput(string data, int? timeout = 5000)
        {
            var complete = false;
            //Define handlers
            TaskCompletionSource<string> outputTcs = new TaskCompletionSource<string>();
            EventHandler<string> outputHandler = null;
            Task timeoutTask = null;

            //Create handlers
            outputHandler = (o, e) =>
            {
                if(!complete && e != null && e.Contains(data))
                    outputTcs.SetResult(e);
            };

            timeoutTask = Task.Run(() =>
            {
                Task.Delay((int)timeout).Wait();
                if(!complete)
                    _log.LogInformation("[WaitOutput] Timeout For Result ({0})", data);
            });

            //Start handlers
            OnOutputReceived += outputHandler;

            var result = await Task.WhenAny(outputTcs.Task, timeoutTask);
            complete = true;
            TryDisposeAll(new IDisposable[]{ outputTcs.Task });
            try
            {
                OnOutputReceived -= outputHandler;
            }catch(Exception e)
            {

            }
            if (result == outputTcs.Task)
                return outputTcs.Task.Result;
            else if (result == timeoutTask)
                throw new Exception("Response timeout");
            else
            {
                throw new Exception("No reponse");
            }
        }

        private static void TryDisposeAll(IDisposable[] objs)
        {
            var list = new List<IDisposable>(objs);
            list.ForEach(item =>
            {
                TryDispose(item);
            });
        }

        private static void TryDispose(IDisposable obj)
        {
            try
            {
                obj.Dispose();
            }catch(Exception e)
            {

            }
        }
    }
}
