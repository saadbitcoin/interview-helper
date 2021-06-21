using System.Threading.Tasks;
using QuestionsList.Core.EntityContracts;
using SharedKernel.Database;
using MicroserviceHandlers.Contracts.QuestionsList;

namespace QuestionsList.Infrastructure.Entities.Tags
{
    public sealed class PgTag : PgEntity, ITag
    {
        private readonly int _id;

        public PgTag(int id, string connectionString) : base(connectionString)
        {
            _id = id;
        }

        private string TagObtainingSQL => $"SELECT id, title FROM tags WHERE id={_id}";

        public async Task<TagSchema> SerializableState()
        {
            var tagData = await QueryFirst(TagObtainingSQL);

            return new TagSchema(tagData.id, tagData.title);
        }
    }
}