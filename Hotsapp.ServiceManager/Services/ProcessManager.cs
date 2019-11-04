using Microsoft.AspNetCore.Hosting;
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
            process = new Process();
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

        public void Stop()
        {
            ForceKill();
        }

        private void ForceKill()
        {
            Console.WriteLine("Killing Yowsup");
            try
            {
                process.Kill();
            }catch(Exception e)
            {
                Console.WriteLine(e);
            }
            Start();
            SendCommand("pkill -9 -f yowsup").Wait();
            Task.Delay(1000).Wait();
            process.Kill();
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

        public async Task<string> WaitOutput(string data, int? timeout = 5000)
        {
            //Define handlers
            TaskCompletionSource<string> outputTcs = new TaskCompletionSource<string>();
            TaskCompletionSource<string> terminatingTcs = new TaskCompletionSource<string>();
            EventHandler<string> outputHandler = null;
            EventHandler terminationHandler = null;
            Task timeoutTask = null;

            //Create handlers
            outputHandler = (o, e) =>
            {
                if(e.Contains(data))
                    outputTcs.SetResult(e);
            };

            timeoutTask = Task.Run(() =>
            {
                Task.Delay((int)timeout).Wait();
            });

            terminationHandler = (o, e) =>
            {
                terminatingTcs.SetResult(null);
            };

            //Start handlers
            OnOutputReceived += outputHandler;
            OnTerminating += terminationHandler;

            var result = await Task.WhenAny(outputTcs.Task, timeoutTask, terminatingTcs.Task);
            TryDisposeAll(new IDisposable[]{ outputTcs.Task, terminatingTcs.Task });
            try
            {
                OnOutputReceived -= outputHandler;
                OnTerminating -= terminationHandler;
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
