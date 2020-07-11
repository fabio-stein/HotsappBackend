using Dapper;
using Hotsapp;
using Hotsapp.Data.Util;
using Hotsapp.Messaging;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using System;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IConnection messaging;
            IModel model;
            var col = new ServiceCollection();
            try
            {
                col.AddMessaging("amqp://user:LJ8XLuiSRR@localhost");
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to Start MessagingService");
            }
            var sp = col.BuildServiceProvider();
            try
            {
                messaging = MessagingFactory.GetConnection();
                model = messaging.CreateModel();
            }
            catch (Exception _) { }

            DataFactory.Initialize(sp, "server=database-1.co098l7654et.sa-east-1.rds.amazonaws.com;port=3306;user=admin;password=xpLpP5cLkAAXaRrkxz0O;database=hotsapp;TreatTinyAsBoolean=false");

            using (var conn = DataFactory.OpenConnection())
            {
                try
                {
                    var t = conn.Query("SELECT NOW()", new { id = 1 });
                    var b = 1;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.ReadLine();
        }
    }
}
