using System.Linq;
using System.Threading.Tasks;
using MicroserviceHandlers.Contracts.QuestionsList;
using SharedKernel.Database;
using TestInterview.Core.EntityContracts;

namespace TestInterview.Infrastructure.Entities.UnansweredQuestions
{
    public sealed class PgUnansweredQuestions : PgEntity, IUnansweredQuestions
    {
        private readonly int _userId;

        public PgUnansweredQuestions(string connectionString, int userId) : base(connectionString)
        {
            _userId = userId;
        }

        public async Task<int> Add(int questionId)
        {
            var id = await QueryFirst<int>($@"
                INSERT INTO 
                    unanswered_questions (user_identifier, question_id)
                VALUES 
                    ({_userId}, {questionId})
            ");

            return id;
        }

        public async Task Remove(int questionId)
        {
            await Query($@"
                DELETE FROM
                    unanswered_questions
                WHERE
                    user_identifier={_userId} AND question_id={questionId}
            ");
        }

        public async Task<IUnansweredQuestion[]> Elements(IQuestionsListMicroservice questionsListMicroservice)
        {
            var ids = await Query<int>($"SELECT question_id FROM unanswered_questions WHERE user_identifier={_userId}");

            return ids.Select(x => new PartialUnansweredQuestion(x, questionsListMicroservice)).ToArray();
        }
    }
}