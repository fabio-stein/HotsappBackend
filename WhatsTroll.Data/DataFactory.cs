using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using WhatsTroll.Data.Model;

namespace WhatsTroll.Data
{
    public class DataFactory
    {
        private static string MySqlConnectionString;
        public DataFactory(string connectionString)
        {
            MySqlConnectionString = connectionString;
        }
        public static DataContext CreateNew()
        {
            var builder = new DbContextOptionsBuilder<DataContext>().UseMySQL(MySqlConnectionString);
            return new DataContext(builder.Options);
        }
    }
}
