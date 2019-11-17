using Hotsapp.Data.Context;
using Hotsapp.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Hotsapp.Data.Util
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

        public static DbConnection OpenConnection()
        {
            var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseMySql(_connectionString);
            var ctx = new DataContext(builder.Options);
            return ctx.Database.GetDbConnection();
        }

        public static NumberContext GetNumberContext()
        {
            var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseMySql(_connectionString);
            return new NumberContext(builder.Options);
        }

        public static ConnectionFlowContext GetConnectionFlowContext()
        {
            var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseMySql(_connectionString);
            return new ConnectionFlowContext(builder.Options);
        }
    }
}
