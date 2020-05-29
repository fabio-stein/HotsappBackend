using Hotsapp.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace Hotsapp.Data.Util
{
    public class DataFactory
    {
        private static string _connectionString { get; set; }
        private static ServiceProvider _serviceProvider { get; set; }

        public static void Initialize(ServiceProvider serviceProvider, string connectionString)
        {
            _connectionString = connectionString;
            _serviceProvider = serviceProvider;
        }

        public static DbConnection OpenConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        public static DataContext GetDataContext()
        {
            return new DataContext(BuildOptions<DataContext>());
        }

        private static DbContextOptions<T> BuildOptions<T>() where T : DbContext
        {
            var optionsBuilder = new DbContextOptionsBuilder<T>();
            optionsBuilder.UseMySql(_connectionString);
            return optionsBuilder.Options;
        }
    }
}
