using System.Threading.Tasks;
using QuestionsList.Core.EntityContracts;
using Dapper;
using SharedKernel.JSON;
using Newtonsoft.Json;
using QuestionsList.Infrastructure.PgEntities.Tags;
using QuestionsList.Infrastructure.PgEntities.Base;

namespace QuestionsList.Infrastructure.PgEntities.Questions
{
    public sealed class PgQuestion : PgEntity, IQuestion
    {
        private readonly int _id;

        public PgQuestion(int id, string connectionString) : base(connectionString)
        {
            _id = id;
        }

        private string QuestionObtainingSQL => $"SELECT id, title, answer FROM questions WHERE id={_id}";

        public async Task<string> JSON()
        {
            using (var connection = Connection())
            {
                var questionData = await connection.QueryFirstAsync(QuestionObtainingSQL);

                var tagSelection = new PgTagSelectionByQuestionIdentifier(_connectionString, questionData.id);
                var tags = await tagSelection.Elements();
                var tagsJSONArray = new JSONArrayAsync(tags);
                var tagsArrayAsJSON = await tagsJSONArray.JSON();

                return JsonConvert.SerializeObject(new
                {
                    id = questionData.id,
                    title = questionData.title,
                    answer = questionData.answer,
                    tags = JsonConvert.DeserializeObject(tagsArrayAsJSON)
                });
            }
        }
    }
}