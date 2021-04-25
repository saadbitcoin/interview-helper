using System.Threading.Tasks;
using KnowledgeBase.Application.Repositories;
using KnowledgeBase.Domain.UseCaseContracts.GetTagByIdentifier;

namespace KnowledgeBase.Application.UseCaseHandlers
{
    public class GetTagByIdentifierHandler : GetTagByIdentifierUseCaseHandler
    {
        private readonly ITagsRepository _tagsRepository;

        public GetTagByIdentifierHandler(ITagsRepository tagsRepository)
        {
            _tagsRepository = tagsRepository;
        }

        public async Task<Response> Handle(Request requestData)
        {
            var result = await _tagsRepository.GetTagById(requestData.TagId);

            return new Response { RequiredTag = result };
        }
    }
}