using System.Linq;
using System.Threading.Tasks;
using KnowledgeBase.Application.Repositories;
using KnowledgeBase.Domain;

namespace KnowledgeBase.Infrastructure.DataAccess.Repositories
{
    internal class LinkedTagsRepository : ILinkedTagsRepository
    {
        private readonly KnowledgeBaseContext _context;

        public LinkedTagsRepository(KnowledgeBaseContext context)
        {
            _context = context;
        }

        public async Task<int> AddLinkedTag(LinkedTag target)
        {
            _context.LinkedTags.Add(target);
            await _context.SaveChangesAsync();

            return target.Id;
        }

        public Task<LinkedTag> GetLinkedTag(string tagTitle, string value)
        {
            return Task.FromResult(_context.LinkedTags.FirstOrDefault(x => x.Tag.Title == tagTitle && x.Value == value));
        }

        public Task<LinkedTag[]> GetLinkedTagsByTagTitle(string tagTitle)
        {
            return Task.FromResult(_context.LinkedTags.Where(x => x.Tag.Title == tagTitle).ToArray());
        }

        public Task<LinkedTag[]> GetLinkedTagsByValue(string value)
        {
            return Task.FromResult(_context.LinkedTags.Where(x => x.Value == value).ToArray());
        }
    }
}