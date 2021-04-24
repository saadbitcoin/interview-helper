using System.Linq;
using System.Threading.Tasks;
using KnowledgeBase.Infrastructure.DataAccess.Models;

namespace KnowledgeBase.Infrastructure.DataAccess.InternalRepositories
{
    internal class QuestionTableRepresentationsRepository
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
    }
}