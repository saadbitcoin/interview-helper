using System.Threading.Tasks;
using TestInterview.Core.EntityContracts;
using TestInterview.Core.Schemas;

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

        public Task<InterviewQuestionSchema> SerializableState()
        {
            return Task.FromResult(new InterviewQuestionSchema(_id, _title));
        }
    }
}