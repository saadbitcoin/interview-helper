using System.Threading.Tasks;
using QuestionsList.Core.EntityContracts;
using QuestionsList.Infrastructure.PgEntities.Base;
using SharedKernel.Selections;
using Dapper;
using System.Linq;
using QuestionsList.Core.Entities;

namespace QuestionsList.Infrastructure.PgEntities.Tags
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
            using (var connection = Connection())
            {
                var tagsData = await connection.QueryAsync($@"
                    SELECT * FROM tags WHERE id IN (
                        SELECT tag_id FROM question_tags WHERE question_id = {_questionId}
                    )
                ");

                return tagsData.Select(x => new PrefilledTag(x.id, x.title)).ToArray();
            }
        }
    }
}