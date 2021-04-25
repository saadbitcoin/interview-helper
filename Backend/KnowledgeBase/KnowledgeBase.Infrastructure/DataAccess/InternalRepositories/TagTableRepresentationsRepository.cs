using System.Linq;
using System.Threading.Tasks;
using KnowledgeBase.Infrastructure.DataAccess.Models;

namespace KnowledgeBase.Infrastructure.DataAccess.InternalRepositories
{
    public class TagTableRepresentationsRepository
    {
        private readonly KnowledgeBaseContext _context;

        public TagTableRepresentationsRepository(KnowledgeBaseContext context)
        {
            _context = context;
        }

        public TagTableRepresentation GetByLinkedTag(LinkedTag source)
        {
            return _context.Tags.FirstOrDefault(x => x.Id == source.TagId);
        }

        public async Task<int> Add(TagTableRepresentation tag)
        {
            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();

            return tag.Id;
        }

        public TagTableRepresentation GetByName(string name)
        {
            return _context.Tags.FirstOrDefault(x => x.Name == name);
        }

        public TagTableRepresentation GetById(int id)
        {
            return _context.Tags.FirstOrDefault(x => x.Id == id);
        }

        public TagTableRepresentation[] GetAll()
        {
            return _context.Tags.ToArray();
        }
    }
}