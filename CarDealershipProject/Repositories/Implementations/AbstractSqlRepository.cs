using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using CarDealershipProject.Core.Domain;
using Dapper;
using Microsoft.Extensions.Options;

namespace CarDealershipProject.Repositories.Implementations
{
    public class AbstractSQLRepository
    {
        private readonly ServiceOptions _serviceOptions;

        public AbstractSQLRepository(IOptionsSnapshot<ServiceOptions> serviceOptions)
        {
            _serviceOptions = serviceOptions.Value;
        }

        protected async Task<SqlConnection> GetConnection()
        {
            var connection = new SqlConnection(_serviceOptions.SQLConnectionString);
            await connection.OpenAsync();
            return connection;
        }

        protected async Task<IEnumerable<T>> QueryAsync<T>(string query, object param = null)
        {
            using (var connection = await GetConnection())
            {
                var result = await connection.QueryAsync<T>(query, param);
                return result;
            }
        }
    }
}
