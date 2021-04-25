using System;
using System.Linq;
using System.Threading.Tasks;
using KnowledgeBase.Application.Repositories;
using KnowledgeBase.Domain;
using KnowledgeBase.Infrastructure.DataAccess.InternalRepositories;

namespace KnowledgeBase.Infrastructure.DataAccess.Repositories
{
    public class TagsRepository : ITagsRepository
    {
        private readonly TagTableRepresentationsRepository _tagTableRepresentationsRepository;
        private readonly LinkedTagsRepository _linkedTagsRepository;

        public TagsRepository(TagTableRepresentationsRepository tagTableRepresentationsRepository,
            LinkedTagsRepository linkedTagsRepository)
        {
            _tagTableRepresentationsRepository = tagTableRepresentationsRepository;
            _linkedTagsRepository = linkedTagsRepository;
        }

        public Task<int> AddNewTag(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task AddNewTagValues(int tagId, string[] values)
        {
            throw new System.NotImplementedException();
        }

        public Task<(int tagId, string tagName)[]> GetAllTagBasicInfo()
        {
            return Task.FromResult(
                _tagTableRepresentationsRepository
                    .GetAll()
                    .AsEnumerable()
                    .Select(x => (tagId: x.Id, tagName: x.Name))
                    .ToArray()
            );
        }

        public Task<Tag> GetTagById(int id)
        {
            var tag = _tagTableRepresentationsRepository.GetById(id);

            if (tag == null)
            {
                return Task.FromResult(null as Tag);
            }

            var linkedTags = _linkedTagsRepository.GetByTagId(id);

            return Task.FromResult(new Tag
            {
                Id = id,
                Title = tag.Name,
                PossibleValues = linkedTags.Select(x => x.Value).ToArray()
            });
        }

        public Task<Tag> GetTagByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}