using System.IO;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace ShortBook.Server.Repository.Npgsql
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class NpgsqlRepository
    {
        private static readonly string _connection;
        
        static NpgsqlRepository()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            _connection = config.GetConnectionString("DataAccessPostgreSqlProvider");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected NpgsqlConnection CreateConnection()
        {
            return new NpgsqlConnection(_connection);
        }
    }
}