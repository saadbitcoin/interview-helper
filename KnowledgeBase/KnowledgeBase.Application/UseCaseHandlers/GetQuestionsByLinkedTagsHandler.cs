using SharedKernel;
using KnowledgeBase.Domain.UseCaseContracts.ObtainQuestionsByLinkedTags;
using System.Threading.Tasks;
using KnowledgeBase.Application.Repositories;

namespace KnowledgeBase.Application.UseCaseHandlers
{
    public class GetQuestionsByLinkedTagsHandler : UseCaseHandler<Request, Response>
    {
        private readonly IQuestionsRepository _questionsRepository;

        public GetQuestionsByLinkedTagsHandler(IQuestionsRepository questionsRepository)
        {
            _questionsRepository = questionsRepository;
        }

        public async Task<Response> Handle(Request requestData)
        {
            var result = await _questionsRepository.GetQuestions(requestData.Source);

            return new Response { Result = result };
        }
    }
}