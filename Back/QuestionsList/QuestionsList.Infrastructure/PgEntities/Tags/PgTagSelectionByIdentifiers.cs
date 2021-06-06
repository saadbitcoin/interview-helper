using System.Threading.Tasks;
using QuestionsList.Core.Entities;
using QuestionsList.Core.EntityContracts;
using SharedKernel.Selections;
using Npgsql;
using Dapper;
using System.Linq;
using QuestionsList.Infrastructure.PgEntities.Base;

namespace QuestionsList.Infrastructure.PgEntities.Tags
{
    public sealed class PgTagSelectionByIdentifiers : PgEntity, ISelectionAsync<ITag>
    {
        private readonly int[] _ids;

        public PgTagSelectionByIdentifiers(int[] identifiers, string connectionString) : base(connectionString)
        {
            _ids = identifiers;
        }

        private string ElementsObtainingSQL => $"SELECT id, title FROM tags WHERE id IN ({string.Join(',', _ids)})";

        public async Task<ITag[]> Elements()
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var result = await connection.QueryAsync(ElementsObtainingSQL);
                var prefilledTags = result.Select(x => new PrefilledTag(x.id, x.title));

                return prefilledTags.ToArray();
            }
        }
    }
}