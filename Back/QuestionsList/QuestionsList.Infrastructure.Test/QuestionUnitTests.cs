using Xunit;
using QuestionsList.Infrastructure.PgEntities.Questions;
using QuestionsList.Infrastructure.PgEntities.Tags;
using Newtonsoft.Json;
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
            var json = question.JSON().Result;
            var deserializedQuestion = JsonConvert.DeserializeObject<dynamic>(json);
            dynamic[] tagsArray = deserializedQuestion.tags.ToObject<dynamic[]>();

            Assert.True(deserializedQuestion.title == "question_title");
            Assert.True(deserializedQuestion.answer == "question_answer");

            Assert.True(tagsArray.Length == 2);
            Assert.Contains(tagsArray, x => x.id == firstTagId && x.title == "tag_1");
            Assert.Contains(tagsArray, x => x.id == secondTagId && x.title == "tag_2");
        }
    }
}
