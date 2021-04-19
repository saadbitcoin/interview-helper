
using System.Linq;
using System.Threading.Tasks;
using KnowledgeBase.Application.Repositories;
using KnowledgeBase.Domain;

namespace KnowledgeBase.Infrastructure.DataAccess.Repositories
{
    internal class QuestionsRepository : IQuestionsRepository
    {
        private readonly KnowledgeBaseContext _context;

        public QuestionsRepository(KnowledgeBaseContext context)
        {
            _context = context;
        }

        public async Task<int> AddQuestion(Question target)
        {
            _context.Questions.Add(target);
            await _context.SaveChangesAsync();

            return target.Id;
        }

        public Task<Question> GetQuestion(int id)
        {
            var entry = _context.Questions.First(x => x.Id == id);
            _context.Entry(entry).Collection(x => x.LinkedTags).Load();

            foreach (var linkedTag in entry.LinkedTags)
            {
                _context.Entry(linkedTag).Reference(x => x.Tag).Load();
            }

            return Task.FromResult(entry);
        }

        public Task<Question[]> GetQuestions(LinkedTag tag)
        {
            return Task.FromResult(_context.Questions.Where(x => x.LinkedTags.Any(x => x.AreSame(tag))).ToArray());
        }

        public Task<Question[]> GetQuestions(LinkedTag[] tags)
        {
            return Task.FromResult(
                _context.Questions.Where(x =>
                    tags.Any(
                        sourceTag => x.LinkedTags.Any(questionTag => questionTag.AreSame(sourceTag))
                    )
                )
                .ToArray()
            );
        }

        public async Task RemoveQuestion(int id)
        {
            var requiredQuestion = _context.Questions.First(x => x.Id == id);
            _context.Questions.Remove(requiredQuestion);
            await _context.SaveChangesAsync();
        }
    }
}