using System.Threading.Tasks;
using QuestionsList.Core.EntityContracts;
using QuestionsList.Infrastructure.PgEntities.Base;
using Npgsql;
using Dapper;
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
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                int questionId = await connection.QueryFirstAsync<int>(InsertQuestionReturningIdSQL(title, answer));
                await connection.ExecuteAsync(InsertQuestionTagsSQL(questionId, tagIds));

                return questionId;
            }
        }

        public async Task<IQuestion[]> LastAdded(int count)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var questionIds = await connection.QueryAsync(LastAddedQuestionIdsSQL(count));

                return questionIds.Select(x => new PgQuestion(x.id, _connectionString)).ToArray();
            }
        }
    }
}