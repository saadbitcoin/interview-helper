using System.Linq;
using System.Threading.Tasks;
using KnowledgeBase.Infrastructure.DataAccess.Models;

namespace KnowledgeBase.Infrastructure.DataAccess.InternalRepositories
{
    public class QuestionTableRepresentationsRepository
    {
        private readonly KnowledgeBaseContext _context;

        public QuestionTableRepresentationsRepository(KnowledgeBaseContext context)
        {
            _context = context;
        }

        public QuestionTableRepresentation GetById(int id)
        {
            return _context.Questions.FirstOrDefault(x => x.Id == id);
        }

        public async Task<int> Add(QuestionTableRepresentation source)
        {
            _context.Questions.Add(source);
            await _context.SaveChangesAsync();

            return source.Id;
        }

        public async Task Remove(int questionId)
        {
            var requiredQuestion = _context.Questions.FirstOrDefault(x => x.Id == questionId);

            if (requiredQuestion == null)
            {
                return;
            }

            _context.Questions.Remove(requiredQuestion);
            await _context.SaveChangesAsync();
        }
    }
}