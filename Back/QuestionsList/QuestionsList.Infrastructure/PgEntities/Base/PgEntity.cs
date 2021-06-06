namespace QuestionsList.Infrastructure.PgEntities.Base
{
    public abstract class PgEntity
    {
        protected readonly string _connectionString;

        protected PgEntity(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}