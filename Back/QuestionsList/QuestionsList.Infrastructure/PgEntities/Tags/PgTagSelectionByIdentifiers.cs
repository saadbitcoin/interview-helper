using System.Threading.Tasks;
using QuestionsList.Core.Entities;
using QuestionsList.Core.EntityContracts;
using SharedKernel.Selections;
using System.Linq;
using SharedKernel.Database;

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
            var result = await Query(ElementsObtainingSQL);
            var prefilledTags = result.Select(x => new PrefilledTag(x.id, x.title));

            return prefilledTags.ToArray();
        }
    }
}