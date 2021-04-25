using System;
using System.Linq;
using System.Threading.Tasks;
using KnowledgeBase.Application.Repositories;
using KnowledgeBase.Domain;

namespace KnowledgeBase.Infrastructure.DataAccess.Repositories
{
    public class TagsRepository : ITagsRepository
    {
        private readonly KnowledgeBaseContext _context;

        public TagsRepository(KnowledgeBaseContext context)
        {
            _context = context;
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
            return Task.FromResult(_context.Tags.AsEnumerable().Select(x => (tagId: x.Id, tagName: x.Name)).ToArray());
        }

        public Task<Tag> GetTagById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Tag> GetTagByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}