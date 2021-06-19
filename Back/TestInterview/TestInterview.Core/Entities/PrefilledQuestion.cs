using System.Threading.Tasks;
using TestInterview.Core.EntityContracts;
using MicroserviceHandlers.Contracts.TestInterview;

namespace TestInterview.Core.Entities
{
    public sealed class PrefilledQuestion : IInterviewQuestion
    {
        private readonly int _id;
        private readonly string _title;

        public PrefilledQuestion(int id, string title)
        {
            _id = id;
            _title = title;
        }

        public Task<InterviewQuestionDTO> SerializableState()
        {
            return Task.FromResult(new InterviewQuestionDTO(_id, _title));
        }
    }
}