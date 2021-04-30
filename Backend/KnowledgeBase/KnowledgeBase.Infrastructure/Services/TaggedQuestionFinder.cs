using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnowledgeBase.Application.Services;
using KnowledgeBase.Domain.Entities;
using KnowledgeBase.Infrastructure.DataAccess;

namespace KnowledgeBase.Infrastructure.Services
{
    public class TaggedQuestionFinder : ITaggedQuestionFinder
    {
        private readonly KnowledgeBaseContext _context;

        public TaggedQuestionFinder(KnowledgeBaseContext context)
        {
            _context = context;
        }

        public async Task<TaggedQuestion[]> FindByTagsIntersection(int[] tagIds)
        {
            var toReturn = new List<TaggedQuestion>();
            var questionIds = _context.QuestionLinkedTags
                .AsEnumerable()
                .GroupBy(x => x.QuestionId)
                .Where(x => tagIds.All(tagId => x.Any(y => y.TagId == tagId)))
                .Select(x => x.Key)
                .Distinct();

            foreach (var questionId in questionIds)
            {
                toReturn.Add(await GetByQuestionId(questionId));
            }

            return toReturn.ToArray();
        }

        public async Task<TaggedQuestion[]> FindByTagsUnion(int[] tagIds)
        {
            var toReturn = new List<TaggedQuestion>();
            var questionIds = _context.QuestionLinkedTags
                .Where(x => tagIds.Any(tagId => x.TagId == tagId))
                .Select(x => x.QuestionId)
                .Distinct()
                .ToArray();

            foreach (var questionId in questionIds)
            {
                toReturn.Add(await GetByQuestionId(questionId));
            }

            return toReturn.ToArray();
        }

        public Task<TaggedQuestion> GetByQuestionId(int questionId)
        {
            var question = _context.Questions.FirstOrDefault(x => x.Id == questionId);

            if (question == null)
            {
                return Task.FromResult(null as TaggedQuestion);
            }

            var questionLinkedTagIds = _context
                .QuestionLinkedTags
                .Where(x => x.QuestionId == questionId)
                .Select(x => x.TagId)
                .Distinct()
                .ToArray();

            var tags = questionLinkedTagIds.Select(tagId => _context.Tags.FirstOrDefault(x => x.Id == tagId)).ToArray();

            return Task.FromResult(
                new TaggedQuestion
                {
                    Answer = question.Answer,
                    Title = question.Title,
                    Id = question.Id,
                    Tags = tags
                }
            );
        }
    }
}