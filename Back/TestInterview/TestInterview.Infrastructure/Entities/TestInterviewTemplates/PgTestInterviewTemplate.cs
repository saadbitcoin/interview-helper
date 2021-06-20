using System.Linq;
using System.Threading.Tasks;
using MicroserviceHandlers.Contracts.TestInterview;
using SharedKernel.Database;
using TestInterview.Core.Entities;
using TestInterview.Core.EntityContracts;

namespace TestInterview.Infrastructure.Entities.TestInterviewTemplates
{
    public sealed class PgTestInterviewTemplate : PgEntity, ITestInterviewTemplate
    {
        private readonly int _id;

        public PgTestInterviewTemplate(string connectionString, int id) : base(connectionString)
        {
            _id = id;
        }

        public async Task<IQuestionsData[]> QuestionsData()
        {
            var rawData = await Query($"SELECT tag_id, questions_count FROM test_interview_template_questions WHERE tag_id={_id}");

            return rawData.Select(x => new PrefilledQuestionsData(x.tag_id, x.questions_count)).ToArray();
        }

        public async Task<TestInterviewTemplateSchema> SerializableState()
        {
            var rawData = await QueryFirst($"SELECT id, title FROM test_interview_templates WHERE id={_id}");

            return new TestInterviewTemplateSchema(rawData.id, rawData.title);
        }
    }
}