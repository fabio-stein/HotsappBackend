using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace WhatsTroll.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                //.UseUrls(config["APP_HOST"].ToString())
                /*.UseKestrel(options =>
                {
                    options.Listen(IPAddress.Any, 5000, listenOptions =>
                    {
                        var cert = new X509Certificate2("certificate.pfx", "Windows81");

                        listenOptions.UseHttps(cert);

                    });

                })*/
                .Build();
    }
}
