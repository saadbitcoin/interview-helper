using System.Threading.Tasks;
using KnowledgeBase.Domain.UseCaseContracts.ObtainQuestionsByLinkedTags;
using KnowledgeBase.Application.Repositories;
using System.Collections.Generic;
using KnowledgeBase.Domain;

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
            var accordedQuestions = await _questionsRepository.GetQuestions(
                requestData.TagName,
                requestData.Values
            );

            return new Response { Result = accordedQuestions };
        }
    }
}