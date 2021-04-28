using System.Threading.Tasks;
using UseCase = KnowledgeBase.Domain.UseCases.GetTaggedQuestionByQuestionId;
using KnowledgeBase.Application.Services;

namespace KnowledgeBase.Application.UseCaseHandlers
{
    public class GetTaggedQuestionByQuestionIdHandler : UseCase.IHandler
    {
        private readonly ITaggedQuestionFinder _taggedQuestionFinder;

        public GetTaggedQuestionByQuestionIdHandler(ITaggedQuestionFinder taggedQuestionFinder)
        {
            _taggedQuestionFinder = taggedQuestionFinder;
        }

        public async Task<UseCase.Response> Handle(UseCase.Request requestData)
        {
            var taggedQuestion = await _taggedQuestionFinder.GetByQuestionId(requestData.QuestionId);

            return new UseCase.Response
            {
                IsFound = taggedQuestion != null,
                TaggedQuestion = taggedQuestion
            };
        }
    }
}