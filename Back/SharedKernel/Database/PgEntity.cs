using Npgsql;
using Dapper;
using System.Threading.Tasks;
using System.Linq;

namespace SharedKernel.Database
{
    public abstract class PgEntity
    {
        protected readonly string _connectionString;

        protected PgEntity(string connectionString)
        {
            _connectionString = connectionString;
        }

        private NpgsqlConnection Connection() => new NpgsqlConnection(_connectionString);

        protected async Task<T[]> Query<T>(string pgsqlQuery)
        {
            using (var connection = Connection())
            {
                var result = await connection.QueryAsync<T>(pgsqlQuery);
                return result.ToArray();
            }
        }

        protected async Task<dynamic[]> Query(string pgsqlQuery)
        {
            var result = await Query<dynamic>(pgsqlQuery);
            return result;
        }

        protected async Task<T> QueryFirst<T>(string pgsqlQuery)
        {
            using (var connection = Connection())
            {
                var result = await connection.QueryFirstAsync<T>(pgsqlQuery);
                return result;
            }
        }

        protected async Task<dynamic> QueryFirst(string pgsqlQuery)
        {
            var result = await QueryFirst<dynamic>(pgsqlQuery);
            return result;
        }
    }
}