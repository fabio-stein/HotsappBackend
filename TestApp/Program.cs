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
            var col = new ServiceCollection();
            var sp = col.BuildServiceProvider();
            DataFactory.Initialize(sp, "server=database-1.co098l7654et.sa-east-1.rds.amazonaws.com;port=3306;user=admin;password=xpLpP5cLkAAXaRrkxz0O;database=hotsapp;TreatTinyAsBoolean=false");

            using (var conn = DataFactory.OpenConnection())
            {
                try
                {
                    conn.Query("SELECT NOW()", new { id = 1 });
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
