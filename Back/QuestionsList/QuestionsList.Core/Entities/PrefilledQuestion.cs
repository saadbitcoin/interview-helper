using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuestionsList.Core.EntityContracts;
using MicroserviceHandlers.Contracts.QuestionsList;

namespace QuestionsList.Core.Entities
{
    public sealed class PrefilledQuestion : IQuestion
    {
        private readonly int _id;
        private readonly string _title;
        private readonly string _answer;
        private readonly ITag[] _tags;

        public PrefilledQuestion(int id, string title, string answer, IEnumerable<ITag> tags) : this(id, title, answer, tags.ToArray())
        {

        }

        public PrefilledQuestion(int id, string title, string answer, ITag[] tags)
        {
            _id = id;
            _title = title;
            _answer = answer;
            _tags = tags;
        }

        public Task<QuestionSchema> SerializableState()
        {
            return Task.FromResult(new QuestionSchema(_id, _title, _answer));
        }

        public Task<ITag[]> Tags()
        {
            return Task.FromResult(_tags);
        }
    }
}