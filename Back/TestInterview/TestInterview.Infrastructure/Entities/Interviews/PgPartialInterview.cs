using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestInterview.Core.EntityContracts;
using MicroserviceHandlers.Contracts.QuestionsList;
using SharedKernel.Database;
using TestInterview.Infrastructure.Entities.InterviewTemplates;
using TestInterview.Core.Entities;

namespace TestInterview.Infrastructure.Entities.Interviews
{
    public sealed class PgPartialInterview : PgEntity, IInterview
    {
        private readonly int _templateId;
        private readonly IQuestionsListMicroservice _questionsListMicroservice;

        public PgPartialInterview(string connectionString, int templateId,
            IQuestionsListMicroservice questionsListMicroservice) : base(connectionString)
        {
            _templateId = templateId;
            _questionsListMicroservice = questionsListMicroservice;
        }

        public async Task<IInterviewQuestion[]> Questions()
        {
            var toReturn = new List<PrefilledQuestion>();
            var pgTemplate = new PgInterviewTemplate(_connectionString, _templateId);
            var questionsData = await pgTemplate.QuestionsData();

            foreach (var data in questionsData)
            {
                var tagId = await data.TagId();
                var count = await data.Count();

                var questionsFullInfo = await _questionsListMicroservice.RandomQuestionsByTag(tagId, count);
                var questions = questionsFullInfo.Select(x => new PrefilledQuestion(x.question.id, x.question.title));

                toReturn.AddRange(questions);
            }

            return toReturn.ToArray();
        }
    }
}