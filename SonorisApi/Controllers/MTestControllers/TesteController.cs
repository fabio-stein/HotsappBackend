using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SonorisApi.Services;

namespace SonorisApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Teste/[action]")]
    public class TesteController : Controller
    {

        [HttpGet]
        public IActionResult WorkerTest([FromServices] ChannelWorkerService service)
        {
            return Ok(service.workers);
        }


        SmtpConfig smtpConfig = new SmtpConfig()
        {
            FromAddress = "ssd@neonsistemas.ml",
            Host = "mail.neonsistemas.ml",
            Password = "devpass",
            Port = 587,
            User = "ssd@neonsistemas.ml"
        };
        public Task Enviar(String msg)
        {
            return SendAsync("Assunto Teste", msg, "fabiolux999@gmail.com");
        }

        public async Task SendAsync(string subject, string body, string to)
        {
            using (var message = new MailMessage(smtpConfig.FromAddress, to)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
            {
                using (var client = new SmtpClient()
                {
                    Port = smtpConfig.Port,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = smtpConfig.Host,
                    Credentials = new NetworkCredential(smtpConfig.User, smtpConfig.Password),
                    EnableSsl = true
                })
                {
                    try
                    {
                        Console.WriteLine("Enviando");
                        await client.SendMailAsync(message);
                        Console.WriteLine("Success");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
        }

        public class SmtpConfig
        {
            public string Host { get; set; }
            public string User { get; set; }
            public string Password { get; set; }
            public int Port { get; set; }
            public string FromAddress { get; set; }
        }

    }
}