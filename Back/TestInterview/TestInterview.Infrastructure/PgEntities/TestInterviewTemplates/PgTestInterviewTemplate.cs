using System.Threading.Tasks;
using Newtonsoft.Json;
using SharedKernel.Database;
using SharedKernel.JSON;

namespace TestInterview.Infrastructure.PgEntities
{
    public sealed class PgTestInterviewTemplate : PgEntity, IJSONSerializableAsync
    {
        private readonly int _id;

        public PgTestInterviewTemplate(string connectionString, int id) : base(connectionString)
        {
            _id = id;
        }

        public async Task<string> JSON()
        {
            var testInterviewBaseData = await QueryFirst(
                $"SELECT id, title FROM test_interview_template WHERE id = {_id}"
            );
            var questionTagsData = await Query(
                $"SELECT tag_id, questions_count FROM test_interview_template_questions WHERE template_id = {_id}"
            );

            var result = new
            {
                id = testInterviewBaseData.id,
                title = testInterviewBaseData.title,
                questionTagsData = questionTagsData
            };

            return JsonConvert.SerializeObject(result);
        }
    }
}