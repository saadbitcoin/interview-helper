using System.Threading.Tasks;
using QuestionsList.Core.EntityContracts;
using SharedKernel.Database;
using System.Linq;
using QuestionsList.Core.Entities;

namespace QuestionsList.Infrastructure.Entities.Tags
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
            var newTagId = await QueryFirst<int>(AddTagSQL(title));
            return newTagId;
        }

        public async Task<ITag[]> Elements()
        {
            var tagsData = await Query(AllTagsSQL);
            return tagsData.Select(x => new PrefilledTag(x.id, x.title)).ToArray();
        }
    }
}