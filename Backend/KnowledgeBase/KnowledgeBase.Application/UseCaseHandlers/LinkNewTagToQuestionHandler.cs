using System.Threading.Tasks;
using KnowledgeBase.Application.Repositories;
using KnowledgeBase.Domain.UseCaseContracts.LinkNewTagsToQuestion;

namespace KnowledgeBase.Application.UseCaseHandlers
{
    public class LinkNewTagToQuestionHandler : LinkNewTagsToQuestionUseCaseHandler
    {
        private readonly IQuestionsRepository _questionsRepository;

        public LinkNewTagToQuestionHandler(IQuestionsRepository questionsRepository)
        {
            _questionsRepository = questionsRepository;
        }

        public async Task<Response> Handle(Request requestData)
        {
            var result = await _questionsRepository.LinkTags(
                requestData.QuestionId,
                requestData.TagTitle,
                requestData.TagValues.ToArray()
            );

            return new Response { CreatedTagsCount = result.createdTags, ExistedTagsCount = result.existedTags };
        }
    }
}