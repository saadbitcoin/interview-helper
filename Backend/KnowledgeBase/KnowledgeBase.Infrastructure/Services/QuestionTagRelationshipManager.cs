using System.Linq;
using System.Threading.Tasks;
using KnowledgeBase.Application.Services;
using KnowledgeBase.Infrastructure.DataAccess;
using KnowledgeBase.Infrastructure.DataAccess.Models;

namespace KnowledgeBase.Infrastructure.Services
{
    public class QuestionTagRelationshipManager : IQuestionTagRelationshipManager
    {
        private readonly KnowledgeBaseContext _context;

        public QuestionTagRelationshipManager(KnowledgeBaseContext context)
        {
            _context = context;
        }

        public async Task<int> LinkTagsToQuestion(int questionId, int[] tagIds)
        {
            var addedTagsCount = 0;

            foreach (var tagId in tagIds)
            {
                var linkExists = _context.QuestionLinkedTags.Any(x => x.QuestionId == questionId && x.TagId == tagId);

                if (!linkExists)
                {
                    _context.QuestionLinkedTags.Add(new QuestionLinkedTag
                    {
                        QuestionId = questionId,
                        TagId = tagId
                    });

                    await _context.SaveChangesAsync();
                    addedTagsCount++;
                }
            }

            return addedTagsCount;
        }

        public async Task<int> WithdrawTagsFromQuestion(int questionId, int[] tagIds)
        {
            var withdrawnTagsCount = 0;

            foreach (var tagId in tagIds)
            {
                var tag = _context.QuestionLinkedTags.FirstOrDefault(x => x.QuestionId == questionId && x.TagId == tagId);

                if (tag == null)
                {
                    continue;
                }

                _context.QuestionLinkedTags.Remove(tag);
                await _context.SaveChangesAsync();
                withdrawnTagsCount++;
            }

            return withdrawnTagsCount;
        }
    }
}