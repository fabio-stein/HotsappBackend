using Microsoft.AspNetCore.Hosting;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hotsapp.ServiceManager.Services
{
    public class ProcessManager
    {
        private Process process = new Process();
        public event EventHandler<string> OnOutputReceived;
        IHostingEnvironment _env;

        public ProcessManager(IHostingEnvironment env)
        {
            _env = env;
        }

        public async Task SendCommand(string command)
        {
            await process.StandardInput.WriteAsync($"{command}\n");
        }

        public void Start()
        {
            Console.WriteLine("Starting new process");
            var startInfo = new ProcessStartInfo();
            
            if(_env.IsDevelopment())
                startInfo.FileName = "wsl";
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

        private async Task ReadOutput(StreamReader sr)
        {
            try
            {
                while (true)
                {
                    var line = await sr.ReadLineAsync();
                    OnOutputReceived.Invoke(this, line);
                }
            }catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public Task<string> WaitOutput(string data, int? timeout = 5000)
        {
            var cts = new CancellationTokenSource();
            TaskCompletionSource<string> tcs = new TaskCompletionSource<string>();

            EventHandler<string> handler = (o, e) =>
            {
                if (!cts.IsCancellationRequested && e.Contains(data))
                {
                    cts.Cancel();
                    new Task(() =>
                    {
                        tcs.SetResult(e);
                    }).Start();
                }
            };

            OnOutputReceived += handler;

            var timeoutTask = new Task(async () =>
            {
                try
                {
                    await Task.Delay((int)timeout, cts.Token);
                }catch(OperationCanceledException e) {
                    OnOutputReceived -= handler;
                }
                if (!cts.Token.IsCancellationRequested)
                {
                    OnOutputReceived -= handler;
                    tcs.SetException(new Exception("No Response"));
                }
            });
            timeoutTask.Start();
            return tcs.Task;
        }
    }
}
