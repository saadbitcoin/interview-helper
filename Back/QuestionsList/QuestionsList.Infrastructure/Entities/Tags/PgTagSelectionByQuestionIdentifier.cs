using System.Threading.Tasks;
using QuestionsList.Core.EntityContracts;
using SharedKernel.Database;
using SharedKernel.Selections;
using System.Linq;
using QuestionsList.Core.Entities;

namespace QuestionsList.Infrastructure.Entities.Tags
{
    public sealed class PgTagSelectionByQuestionIdentifier : PgEntity, ISelectionAsync<ITag>
    {
        private readonly int _questionId;

        public PgTagSelectionByQuestionIdentifier(string connectionString, int questionId) : base(connectionString)
        {
            _questionId = questionId;
        }

        public async Task<ITag[]> Elements()
        {
            var tagsData = await Query($@"
                SELECT * FROM tags WHERE id IN (
                    SELECT tag_id FROM question_tags WHERE question_id = {_questionId}
                )
            ");

            return tagsData.Select(x => new PrefilledTag(x.id, x.title)).ToArray();
        }
    }
}