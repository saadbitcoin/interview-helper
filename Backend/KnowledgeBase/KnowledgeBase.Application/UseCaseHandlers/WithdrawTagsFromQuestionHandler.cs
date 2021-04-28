using System.Threading.Tasks;
using KnowledgeBase.Application.Services;
using UseCase = KnowledgeBase.Domain.UseCases.WithdrawTagsFromQuestion;

namespace KnowledgeBase.Application.UseCaseHandlers
{
    public class WithdrawTagsFromQuestionHandler : UseCase.IHandler
    {
        private readonly IQuestionTagRelationshipManager _questionTagRelationshipManager;

        public WithdrawTagsFromQuestionHandler(IQuestionTagRelationshipManager questionTagRelationshipManager)
        {
            _questionTagRelationshipManager = questionTagRelationshipManager;
        }

        public async Task<UseCase.Response> Handle(UseCase.Request requestData)
        {
            var withdrawnTagsCount = await _questionTagRelationshipManager.WithdrawTagsFromQuestion(
                requestData.QuestionId,
                requestData.TagIds
            );

            return new UseCase.Response { WithdrawnTagsCount = withdrawnTagsCount };
        }
    }
}