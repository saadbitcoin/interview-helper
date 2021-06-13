using Npgsql;

namespace QuestionsList.Infrastructure.PgEntities.Base
{
    public abstract class PgEntity
    {
        protected readonly string _connectionString;

        protected PgEntity(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected NpgsqlConnection Connection()
        {
            return new NpgsqlConnection(_connectionString);
        }
    }
}