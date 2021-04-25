using System.Threading.Tasks;
using KnowledgeBase.Application.Repositories;
using KnowledgeBase.Domain.UseCaseContracts.AddTag;

namespace KnowledgeBase.Application.UseCaseHandlers
{
    public class AddTagHandler : AddTagUseCaseHandler
    {
        private readonly ITagsRepository _tagsRepository;

        public AddTagHandler(ITagsRepository tagsRepository)
        {
            _tagsRepository = tagsRepository;
        }

        public async Task<Response> Handle(Request requestData)
        {
            var newTagIdentifier = await _tagsRepository.AddNewTag(requestData.Title);
            await _tagsRepository.AddNewTagValues(newTagIdentifier, requestData.InitialValues.ToArray());

            return new Response { TagId = newTagIdentifier };
        }
    }
}