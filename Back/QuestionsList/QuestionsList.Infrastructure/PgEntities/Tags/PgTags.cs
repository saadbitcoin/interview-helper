using System.Threading.Tasks;
using QuestionsList.Core.EntityContracts;
using QuestionsList.Infrastructure.PgEntities.Base;
using Npgsql;
using Dapper;
using System.Linq;
using QuestionsList.Core.Entities;

namespace QuestionsList.Infrastructure.PgEntities.Tags
{
    public sealed class PgTags : PgEntity, ITags
    {
        public PgTags(string connectionString) : base(connectionString)
        {
        }

        private string AddTagSQL(string title)
            => $"INSERT INTO tags (title) VALUES ('{title}') RETURNING id";

        private string AllTagsSQL
            = "SELECT id, title FROM tags";

        public async Task<int> Add(string title)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                System.Console.Write(AddTagSQL(title));
                var newTagId = await connection.QueryFirstAsync<int>(AddTagSQL(title));
                return newTagId;
            }
        }

        public async Task<ITag[]> Elements()
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var tagsData = await connection.QueryAsync(AllTagsSQL);
                return tagsData.Select(x => new PrefilledTag(x.id, x.title)).ToArray();
            }
        }
    }
}