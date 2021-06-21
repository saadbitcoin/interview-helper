using System.Threading.Tasks;
using QuestionsList.Core.EntityContracts;
using MicroserviceHandlers.Contracts.QuestionsList;

namespace QuestionsList.Core.Entities
{
    public sealed class PrefilledTag : ITag
    {
        private readonly int _id;
        private readonly string _title;

        public PrefilledTag(int id, string title)
        {
            _id = id;
            _title = title;
        }

        public Task<TagSchema> SerializableState()
        {
            return Task.FromResult(new TagSchema(_id, _title));
        }
    }
}