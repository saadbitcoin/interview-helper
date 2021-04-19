using SharedKernel;
using KnowledgeBase.Domain.UseCaseContracts.ObtainQuestionByIdentifier;
using System.Threading.Tasks;
using KnowledgeBase.Application.Repositories;

namespace KnowledgeBase.Application.UseCaseHandlers
{
    public class ObtainQuestionByIdentifierHandler : UseCaseHandler<Request, Response>
    {
        private readonly IQuestionsRepository _questionsRepository;

        public ObtainQuestionByIdentifierHandler(IQuestionsRepository questionsRepository)
        {
            _questionsRepository = questionsRepository;
        }

        public async Task<Response> Handle(Request requestData)
        {
            var targetQuestion = await _questionsRepository.GetQuestion(requestData.QuestionIdentifier);

            return new Response { Result = targetQuestion };
        }
    }
}