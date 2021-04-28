using System.Threading.Tasks;
using KnowledgeBase.Application.Services;
using UseCase = KnowledgeBase.Domain.UseCases.LinkTagsToQuestion;

namespace KnowledgeBase.Application.UseCaseHandlers
{
    public class LinkTagsToQuestionHandler : UseCase.IHandler
    {
        private readonly IQuestionTagRelationshipManager _questionTagRelationshipManager;

        public LinkTagsToQuestionHandler(IQuestionTagRelationshipManager questionTagRelationshipManager)
        {
            _questionTagRelationshipManager = questionTagRelationshipManager;
        }

        public async Task<UseCase.Response> Handle(UseCase.Request requestData)
        {
            var linkedTagsCount = await _questionTagRelationshipManager.LinkTagsToQuestion(
                requestData.QuestionId,
                requestData.TagIds
            );

            return new UseCase.Response { LinkedTagsCount = linkedTagsCount };
        }
    }
}