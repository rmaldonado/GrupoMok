
using Infraestructure.Interface.Connection;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Infraestructure.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;
        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection
        {
            get
            {
                var sqlConnection = new SqlConnection
                {
                    ConnectionString = _configuration.GetConnectionString("ConexionProd")
                };
                sqlConnection.Open();
                return sqlConnection;
            }
        }
    }
}