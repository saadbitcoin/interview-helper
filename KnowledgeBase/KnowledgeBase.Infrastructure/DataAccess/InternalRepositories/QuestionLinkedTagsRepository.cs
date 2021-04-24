using System.Linq;
using System.Threading.Tasks;
using KnowledgeBase.Infrastructure.DataAccess.Models;

namespace KnowledgeBase.Infrastructure.DataAccess.InternalRepositories
{
    internal class QuestionLinkedTagsRepository
    {
        private readonly KnowledgeBaseContext _context;

        public QuestionLinkedTagsRepository(KnowledgeBaseContext context)
        {
            _context = context;
        }

        public QuestionLinkedTag[] GetByQuestionId(int questionId)
        {
            return _context.QuestionLinkedTags.Where(x => x.QuestionId == questionId).ToArray();
        }

        public async Task<int> Add(QuestionLinkedTag target)
        {
            _context.QuestionLinkedTags.Add(target);
            await _context.SaveChangesAsync();

            return target.Id;
        }
    }
}