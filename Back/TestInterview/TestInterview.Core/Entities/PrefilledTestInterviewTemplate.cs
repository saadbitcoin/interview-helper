using System.Threading.Tasks;
using MicroserviceHandlers.Contracts.TestInterview;
using TestInterview.Core.EntityContracts;

namespace TestInterview.Core.Entities
{
    public sealed class PrefilledTestInterviewTemplate : ITestInterviewTemplate
    {
        private readonly ITestInterviewTemplate _source;
        private readonly int _id;
        private readonly string _title;

        public PrefilledTestInterviewTemplate(ITestInterviewTemplate source, int id, string title)
        {
            _source = source;
            _id = id;
            _title = title;
        }

        public Task<IQuestionsData[]> QuestionsData() => _source.QuestionsData();

        public Task<TestInterviewTemplateSchema> SerializableState()
        {
            return Task.FromResult(new TestInterviewTemplateSchema(_id, _title));
        }
    }
}