using System.Threading.Tasks;
using KnowledgeBase.Application.Repositories;
using KnowledgeBase.Domain.UseCaseContracts.WithdrawTagsFromQuestion;

namespace KnowledgeBase.Application.UseCaseHandlers
{
    public class WithdrawTagsFromQuestionHandler : WithdrawTagsFromQuestionUseCaseHandler
    {
        public IQuestionsRepository _questionsRepository;

        public WithdrawTagsFromQuestionHandler(IQuestionsRepository questionsRepository)
        {
            _questionsRepository = questionsRepository;
        }

        public async Task<Response> Handle(Request requestData)
        {
            var withdrawTagsCount = await _questionsRepository.WithdrawTags(
                requestData.QuestionId,
                requestData.TagTitle,
                requestData.TagValues.ToArray()
            );

            return new Response { WithdrawnLinkedTagsCount = withdrawTagsCount };
        }
    }
}