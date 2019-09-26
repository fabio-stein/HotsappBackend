﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotsapp.Data.Model;
using Hotsapp.Data.Context;

namespace Hotsapp.ServiceManager.Util
{
    public class DataFactory
    {
        private static string _connectionString;
        public DataFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public static DataContext GetContext()
        {
            var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseMySql(_connectionString);
            return new DataContext(builder.Options);
            //return DIConfig.GetSetvice<DataContext>();
        }

        public static NumberContext GetNumberContext()
        {
            var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseMySql(_connectionString);
            return new NumberContext(builder.Options);
        }
    }
}
