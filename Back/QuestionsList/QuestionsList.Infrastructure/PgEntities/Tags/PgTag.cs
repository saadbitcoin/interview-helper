using System.Threading.Tasks;
using QuestionsList.Core.EntityContracts;
using Newtonsoft.Json;
using SharedKernel.Database;

namespace QuestionsList.Infrastructure.PgEntities.Tags
{
    public sealed class PgTag : PgEntity, ITag
    {
        private readonly int _id;

        public PgTag(int id, string connectionString) : base(connectionString)
        {
            _id = id;
        }

        private string TagObtainingSQL => $"SELECT id, title FROM tags WHERE id={_id}";

        public async Task<string> JSON()
        {
            var tagData = await QueryFirst(TagObtainingSQL);
            return JsonConvert.SerializeObject(new { id = tagData.id, title = tagData.title });
        }
    }
}