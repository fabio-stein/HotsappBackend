using Dapper;
using Hotsapp.Data.Util;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var col = new ServiceCollection();
            var sp = col.BuildServiceProvider();
            DataFactory.Initialize(sp, "server=database-1.co098l7654et.sa-east-1.rds.amazonaws.com;port=3306;user=admin;password=xpLpP5cLkAAXaRrkxz0O;database=hotsapp;TreatTinyAsBoolean=false");

            var files = Directory.GetFiles("youtube/");

            var conn = DataFactory.OpenConnection();
            foreach(var name in files)
            {
                try
                {
                    var file = File.ReadAllText(name);
                    var id = name.Split('/')[1].Split(".info")[0];
                    conn.Query("INSERT INTO demo_data (Id, Data) VALUES (@id, @data)", new { id = id, data = file });
                }catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            var t = 1;
        }
    }
}
