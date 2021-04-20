using System.Linq;
using System.Threading.Tasks;
using KnowledgeBase.Application.Repositories;
using KnowledgeBase.Domain;

namespace KnowledgeBase.Infrastructure.DataAccess.Repositories
{
    internal class TagsRepository : ITagsRepository
    {
        private readonly KnowledgeBaseContext _context;

        public TagsRepository(KnowledgeBaseContext context)
        {
            _context = context;
        }

        public async Task<int> AddTag(Tag target)
        {
            _context.Tags.Add(target);
            await _context.SaveChangesAsync();

            return target.Id;
        }

        public Task<Tag> GetTag(string title)
        {
            return Task.FromResult(_context.Tags.FirstOrDefault(x => x.Title == title));
        }
    }
}