using System.Collections.Generic;
using System.Threading.Tasks;
using KnowledgeBase.Application.Services;
using KnowledgeBase.Domain.Entities;
using UseCase = KnowledgeBase.Domain.UseCases.GetTaggedQuestionsByTagIds;

namespace KnowledgeBase.Application.UseCaseHandlers
{
    public class GetTaggedQuestionsByTagIdsHandler : UseCase.IHandler
    {
        private readonly ITaggedQuestionFinder _taggedQuestionFinder;

        public GetTaggedQuestionsByTagIdsHandler(ITaggedQuestionFinder taggedQuestionFinder)
        {
            _taggedQuestionFinder = taggedQuestionFinder;
        }

        public async Task<UseCase.Response> Handle(UseCase.Request requestData)
        {
            switch (requestData.Mode)
            {
                case UseCase.Modes.Intersection:
                    return new UseCase.Response
                    {
                        Questions = await _taggedQuestionFinder.FindByTagsIntersection(
                            requestData.Identifiers
                        )
                    };
                case UseCase.Modes.Union:
                    return new UseCase.Response
                    {
                        Questions = await _taggedQuestionFinder.FindByTagsUnion(
                            requestData.Identifiers
                        )
                    };
            }

            return new UseCase.Response { Questions = new List<TaggedQuestion>().ToArray() };
        }
    }
}