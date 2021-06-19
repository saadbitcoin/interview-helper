using Xunit;
using QuestionsList.Infrastructure.Entities.Questions;
using QuestionsList.Infrastructure.Entities.Tags;
using System.Linq;

namespace QuestionsList.Infrastructure.Test
{
    public class QuestionUnitTests
    {
        private readonly string _connectionString = "Server=localhost;Port=5432;Database=questions_list_test;User Id=postgres;Password=postgres;";

        [Fact]
        public void Creation()
        {
            var tags = new PgTags(_connectionString);
            var firstTagId = tags.Add("tag_1").Result;
            var secondTagId = tags.Add("tag_2").Result;
            var questions = new PgQuestions(_connectionString);
            var questionId = questions.Add("question_title", "question_answer", new[] { firstTagId, secondTagId }).Result;
            var question = new PgQuestion(questionId, _connectionString);
            var serializableData = question.SerializableState().Result;

            Assert.True(serializableData.title == "question_title");
            Assert.True(serializableData.answer == "question_answer");

            var questionTags = question.Tags().Result.Select(x => x.SerializableState().Result).ToArray();

            Assert.True(questionTags.Length == 2);
            Assert.Contains(questionTags, x => x.id == firstTagId && x.title == "tag_1");
            Assert.Contains(questionTags, x => x.id == secondTagId && x.title == "tag_2");
        }
    }
}
