using System.Threading.Tasks;
using MicroserviceHandlers.Contracts.TestInterview;
using TestInterview.Core.EntityContracts;

namespace TestInterview.Core.Entities
{
    public sealed class PrefilledQuestionsData : IQuestionsData
    {
        private readonly int _tagId;
        private readonly int _questionsCount;

        public PrefilledQuestionsData(int tagId, int questionsCount)
        {
            _tagId = tagId;
            _questionsCount = questionsCount;
        }

        public Task<int> Count()
        {
            return Task.FromResult(_questionsCount);
        }

        public Task<int> TagId()
        {
            return Task.FromResult(_tagId);
        }
    }
}