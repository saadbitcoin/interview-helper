using System.Linq;
using System.Threading.Tasks;
using KnowledgeBase.Infrastructure.DataAccess.Models;

namespace KnowledgeBase.Infrastructure.DataAccess.InternalRepositories
{
    public class LinkedTagsRepository
    {
        private readonly KnowledgeBaseContext _context;

        public LinkedTagsRepository(KnowledgeBaseContext context)
        {
            _context = context;
        }

        public LinkedTag GetByQuestionLinkedTag(QuestionLinkedTag source)
        {
            return _context.LinkedTags.FirstOrDefault(x => x.Id == source.LinkedTagId);
        }

        public LinkedTag GetByTagIdAndValue(int tagId, string value)
        {
            return _context.LinkedTags.FirstOrDefault(x => x.TagId == tagId && x.Value == value);
        }

        public LinkedTag[] GetByTagId(int tagId)
        {
            return _context.LinkedTags.Where(x => x.TagId == tagId).ToArray();
        }

        public async Task<int> Add(LinkedTag target)
        {
            _context.LinkedTags.Add(target);
            await _context.SaveChangesAsync();

            return target.Id;
        }
    }
}