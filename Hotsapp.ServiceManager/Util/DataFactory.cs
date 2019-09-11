using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsTroll.Data.Model;

namespace Hotsapp.ServiceManager.Util
{
    public class DataFactory
    {
        public static DataContext GetContext()
        {
            var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseMySQL("server=hotsapp.csgrxoop9tel.sa-east-1.rds.amazonaws.com;port=3306;user=hotsapp;password=NbK2CMOfkkxFqryJF1AO;database=hotsapp");
            return new DataContext(builder.Options);
            //return DIConfig.GetSetvice<DataContext>();
        }
    }
}
