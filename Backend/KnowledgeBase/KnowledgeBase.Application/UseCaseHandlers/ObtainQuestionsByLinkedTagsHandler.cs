using System.Threading.Tasks;
using KnowledgeBase.Domain.UseCaseContracts.ObtainQuestionsByLinkedTags;
using KnowledgeBase.Application.Repositories;

namespace KnowledgeBase.Application.UseCaseHandlers
{
    public class ObtainQuestionsByLinkedTagsHandler : ObtainQuestionsByLinkedTagsUseCaseHandler
    {
        private readonly IQuestionsRepository _questionsRepository;

        public ObtainQuestionsByLinkedTagsHandler(IQuestionsRepository questionsRepository)
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