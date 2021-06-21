using System.Threading.Tasks;
using TestInterview.Core.EntityContracts;
using TestInterview.Core.Schemas;

namespace TestInterview.Core.Entities
{
    public sealed class PrefilledTestInterviewTemplate : IInterviewTemplate
    {
        private readonly IInterviewTemplate _source;
        private readonly int _id;
        private readonly string _title;

        public PrefilledTestInterviewTemplate(IInterviewTemplate source, int id, string title)
        {
            _source = source;
            _id = id;
            _title = title;
        }

        public Task<IQuestionsData[]> QuestionsData() => _source.QuestionsData();

        public Task<InterviewTemplateSchema> SerializableState()
        {
            return Task.FromResult(new InterviewTemplateSchema(_id, _title));
        }
    }
}