using System.Threading.Tasks;
using QuestionsList.Core.EntityContracts;
using System.Linq;
using QuestionsList.Core.Entities;
using SharedKernel.Database;

namespace QuestionsList.Infrastructure.PgEntities.Questions
{
    public sealed class PgUnionTaggedQuestionSelection : PgEntity, IQuestionsSelection
    {
        private readonly int[] _tagIds;

        public PgUnionTaggedQuestionSelection(int[] tagIdentifiers, string connectionString) : base(connectionString)
        {
            _tagIds = tagIdentifiers;
        }

        private string QuestionDataObtainingSQL => $@"
            WITH 
                according_question_ids AS (
                    SELECT question_id FROM question_tags WHERE tag_id IN ({ string.Join(", ", _tagIds) })
                ),
                according_questions AS (
                    SELECT * FROM questions WHERE id IN (SELECT * FROM according_question_ids)
                )

            SELECT 
                q.id AS id, q.title AS title, q.answer AS answer, t.id AS tag_id, t.title AS tag_title 
            
            FROM 
                according_questions as q

            INNER JOIN question_tags AS qt ON q.id = qt.question_id
            INNER JOIN tags AS t ON t.id = qt.tag_id
        ";

        private string RandomQuestionDataObtainingSQL(int count) => QuestionDataObtainingSQL + $" ORDER BY RANDOM() LIMIT {count}";

        private async Task<IQuestion[]> GetElements(string query)
        {
            var questionData = await Query(query);
            return questionData.GroupBy(x => x.id).Select(x =>
            {
                var question = x.First();
                var tags = x.Select(x => new PrefilledTag(x.tag_id, x.tag_title));
                return new PrefilledQuestion(question.id, question.title, question.answer, tags);
            }).ToArray();
        }

        public Task<IQuestion[]> Elements() => GetElements(QuestionDataObtainingSQL);

        public Task<IQuestion[]> RandomElements(int count) => GetElements(RandomQuestionDataObtainingSQL(count));
    }
}