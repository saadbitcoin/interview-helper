using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestInterview.Core.EntityContracts;
using MicroserviceHandlers.Contracts.QuestionsList;
using TestInterview.Core.Entities;
using SharedKernel.Database;

namespace TestInterview.Infrastructure.Entities.TestInterviews
{
    public sealed class PgPartialTestInterview : PgEntity, ITestInterview
    {
        public record QuestionsData(int tagId, int questionsCount);

        private readonly QuestionsData[] _questionsData;
        private readonly IQuestionsListMicroservice _questionsListMicroservice;

        public PgPartialTestInterview(string connectionString, IEnumerable<QuestionsData> questionsData,
            IQuestionsListMicroservice questionsListMicroservice) : this(connectionString, questionsData.ToArray(), questionsListMicroservice)
        {

        }

        public PgPartialTestInterview(string connectionString, QuestionsData[] questionsData,
            IQuestionsListMicroservice questionsListMicroservice) : base(connectionString)
        {
            _questionsData = questionsData;
            _questionsListMicroservice = questionsListMicroservice;
        }

        public Task MarkUnanswered(int questionId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IInterviewQuestion[]> Questions()
        {
            var questionsArray = await Task.WhenAll(
                _questionsData.Select(x => _questionsListMicroservice.RandomQuestionsByTag(x.tagId, x.questionsCount))
            );

            return questionsArray.SelectMany(x => x).Select(x => new PrefilledQuestion(x.question.id, x.question.title)).ToArray();
        }
    }
}