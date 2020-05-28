using Hotsapp.Data.Model;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace Hotsapp.Data.Util
{
    public class DataFactory
    {
        private string _connectionString;
        private ServiceProvider _serviceProvider;
        public DataFactory(ServiceProvider serviceProvider, string connectionString)
        {
            _connectionString = connectionString;
            _serviceProvider = serviceProvider;
        }

        public DbConnection OpenConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        public DataContext GetDataContext()
        {
            return _serviceProvider.GetRequiredService<DataContext>();
        }
    }
}
