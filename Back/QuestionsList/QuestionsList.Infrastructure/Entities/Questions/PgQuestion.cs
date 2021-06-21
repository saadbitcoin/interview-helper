using System.Threading.Tasks;
using QuestionsList.Core.EntityContracts;
using QuestionsList.Infrastructure.Entities.Tags;
using SharedKernel.Database;
using MicroserviceHandlers.Contracts.QuestionsList;

namespace QuestionsList.Infrastructure.Entities.Questions
{
    public sealed class PgQuestion : PgEntity, IQuestion
    {
        private readonly int _id;

        public PgQuestion(int id, string connectionString) : base(connectionString)
        {
            _id = id;
        }

        private string QuestionObtainingSQL => $"SELECT id, title, answer FROM questions WHERE id={_id}";

        public async Task<QuestionSchema> SerializableState()
        {
            var questionData = await QueryFirst(QuestionObtainingSQL);

            return new QuestionSchema(questionData.id, questionData.title, questionData.answer);
        }

        public Task<ITag[]> Tags()
        {
            var tagSelection = new PgTagSelectionByQuestionIdentifier(_connectionString, _id);
            return tagSelection.Elements();
        }
    }
}