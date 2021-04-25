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

        public Task<string[]> GetAllTagNames()
        {
            throw new System.NotImplementedException();
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