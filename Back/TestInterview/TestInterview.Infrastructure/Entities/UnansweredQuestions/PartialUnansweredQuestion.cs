using System.Threading.Tasks;
using MicroserviceHandlers.Contracts.QuestionsList;
using MicroserviceHandlers.Contracts.TestInterview;
using TestInterview.Core.EntityContracts;

namespace TestInterview.Infrastructure.Entities.UnansweredQuestions
{
    public sealed class PartialUnansweredQuestion : IUnansweredQuestion
    {
        private readonly int _questionId;
        private IQuestionsListMicroservice _questionsListMicroservice;

        public PartialUnansweredQuestion(int questionId, IQuestionsListMicroservice questionsListMicroservice)
        {
            _questionId = questionId;
            _questionsListMicroservice = questionsListMicroservice;
        }

        private Task<QuestionWithTagSchema> FullQuestionModel()
        {
            return _questionsListMicroservice.Question(_questionId);
        }

        public async Task<string> Answer()
        {
            var fullQuestionData = await FullQuestionModel();

            return fullQuestionData.question.answer;
        }

        public async Task<InterviewQuestionSchema> SerializableState()
        {
            var fullQuestionData = await FullQuestionModel();

            return new InterviewQuestionSchema(fullQuestionData.question.id, fullQuestionData.question.title);
        }
    }
}