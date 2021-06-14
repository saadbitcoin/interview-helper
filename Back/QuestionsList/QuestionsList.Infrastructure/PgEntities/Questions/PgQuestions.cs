using System.Threading.Tasks;
using QuestionsList.Core.EntityContracts;
using SharedKernel.Database;
using System.Linq;

namespace QuestionsList.Infrastructure.PgEntities.Questions
{
    public sealed class PgQuestions : PgEntity, IQuestions
    {
        public PgQuestions(string connectionString) : base(connectionString)
        {
        }

        private string InsertQuestionReturningIdSQL(string title, string answer)
            => $"INSERT INTO questions (title, answer) VALUES ('{title}', '{answer}') RETURNING id";

        private string InsertQuestionTagsSQL(int questionId, int[] tagIds)
            => $"INSERT INTO question_tags (question_id, tag_id) VALUES {string.Join(", ", tagIds.Select(x => $"({questionId}, {x})"))}";

        private string LastAddedQuestionIdsSQL(int count)
            => $"SELECT id FROM questions ORDER BY id DESC LIMIT {count}";

        public async Task<int> Add(string title, string answer, int[] tagIds)
        {
            int questionId = await QueryFirst<int>(InsertQuestionReturningIdSQL(title, answer));
            await Query(InsertQuestionTagsSQL(questionId, tagIds));

            return questionId;
        }

        public async Task<IQuestion[]> LastAdded(int count)
        {
            var questionIds = await Query(LastAddedQuestionIdsSQL(count));

            return questionIds.Select(x => new PgQuestion(x.id, _connectionString)).ToArray();
        }
    }
}