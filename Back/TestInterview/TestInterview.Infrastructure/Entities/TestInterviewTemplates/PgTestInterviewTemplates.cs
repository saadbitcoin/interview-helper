using System.Linq;
using System.Threading.Tasks;
using SharedKernel.Database;
using TestInterview.Core.Entities;
using TestInterview.Core.EntityContracts;

namespace TestInterview.Infrastructure.Entities.TestInterviewTemplates
{
    public sealed class PgTestInterviewTemplates : PgEntity, ITestInterviewTemplates
    {
        public PgTestInterviewTemplates(string connectionString) : base(connectionString)
        {

        }

        private string TestInterviewTemplateCreatingSQL(string title) =>
            $"INSERT INTO test_interview_templates (title) VALUES ('${title}') RETURNING id";

        private string QuestionDataLinkingSQL(int templateId, (int tagId, int count)[] questionData) => $@"
            INSERT INTO 
                test_interview_template_questions (tag_id, questions_count, template_id) 
            VALUES 
                ${string.Join(", ", questionData.Select(x => $"({x.tagId}, {x.count}, {templateId})"))}
        ";

        private string TestInterviewTemplatesObtainingSQL
            = "SELECT id, title FROM test_interview_templates";

        public async Task<int> Create(string title, (int tagId, int count)[] questionData)
        {
            var id = await QueryFirst<int>(TestInterviewTemplateCreatingSQL(title));
            await Query(QuestionDataLinkingSQL(id, questionData));

            return id;
        }

        public async Task<ITestInterviewTemplate[]> Elements()
        {
            var templatesRawData = await Query(TestInterviewTemplatesObtainingSQL);
            return templatesRawData.Select(x =>
            {
                var pgTemplate = new PgTestInterviewTemplate(_connectionString, x.id);

                return new PrefilledTestInterviewTemplate(pgTemplate, x.id, x.title);
            }).ToArray();
        }
    }
}