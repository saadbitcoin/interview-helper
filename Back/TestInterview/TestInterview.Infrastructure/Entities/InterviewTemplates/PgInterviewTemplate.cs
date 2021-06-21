using System.Linq;
using System.Threading.Tasks;
using SharedKernel.Database;
using TestInterview.Core.Entities;
using TestInterview.Core.EntityContracts;
using TestInterview.Core.Schemas;

namespace TestInterview.Infrastructure.Entities.InterviewTemplates
{
    public sealed class PgInterviewTemplate : PgEntity, IInterviewTemplate
    {
        private readonly int _id;

        public PgInterviewTemplate(string connectionString, int id) : base(connectionString)
        {
            _id = id;
        }

        public async Task<IQuestionsData[]> QuestionsData()
        {
            var rawData = await Query($"SELECT tag_id, questions_count FROM test_interview_template_questions WHERE template_id={_id}");

            return rawData.Select(x => new PrefilledQuestionsData(x.tag_id, x.questions_count)).ToArray();
        }

        public async Task<InterviewTemplateSchema> SerializableState()
        {
            var rawData = await QueryFirst($"SELECT id, title FROM test_interview_templates WHERE id={_id}");

            return new InterviewTemplateSchema(rawData.id, rawData.title);
        }
    }
}