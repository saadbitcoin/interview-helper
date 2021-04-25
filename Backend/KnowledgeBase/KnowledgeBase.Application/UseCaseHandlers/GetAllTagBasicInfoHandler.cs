using System.Linq;
using System.Threading.Tasks;
using KnowledgeBase.Application.Repositories;
using KnowledgeBase.Domain.UseCaseContracts.GetAllTagBasicInfo;

namespace KnowledgeBase.Application.UseCaseHandlers
{
    public class GetAllTagBasicInfoHandler : GetAllTagBasicInfoUseCaseHandler
    {
        private readonly ITagsRepository _tagsRepository;

        public GetAllTagBasicInfoHandler(ITagsRepository tagsRepository)
        {
            _tagsRepository = tagsRepository;
        }

        public async Task<Response> Handle(Request requestData)
        {
            var result = await _tagsRepository.GetAllTagBasicInfo();

            return new Response { Items = result.Select(x => new BasicTagInfo { Id = x.tagId, Name = x.tagName }).ToArray() };
        }
    }
}