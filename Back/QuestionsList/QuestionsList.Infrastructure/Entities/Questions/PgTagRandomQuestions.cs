using System.Threading.Tasks;
using QuestionsList.Core.EntityContracts;
using SharedKernel.Database;
using SharedKernel.Selections;
using System.Linq;
using QuestionsList.Core.Entities;
using QuestionsList.Infrastructure.Entities.Tags;

namespace QuestionsList.Infrastructure.Entities.Questions
{
    public sealed class PgTagRandomQuestions : PgEntity, IRandomAccessSelectionAsync<IQuestion>
    {
        private readonly int _tagId;

        public PgTagRandomQuestions(string connectionString, int tagId) : base(connectionString)
        {
            _tagId = tagId;
        }

        public async Task<IQuestion[]> RandomElements(int count)
        {
            var questionsData = await Query($@"
                SELECT * FROM questions WHERE id IN (
                    SELECT question_id FROM question_tags WHERE tag_id = {_tagId}
                )
                ORDER BY RANDOM()
                LIMIT {count}
            ");

            var questions = await Task.WhenAll(questionsData.Select(async x =>
            {
                var tagsSelection = new PgTagSelectionByQuestionIdentifier(_connectionString, x.id);
                var tags = await tagsSelection.Elements();
                return new PrefilledQuestion(x.id, x.title, x.answer, tags);
            }));

            return questions;
        }
    }
}