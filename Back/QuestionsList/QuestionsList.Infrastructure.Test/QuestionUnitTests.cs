using System;
using Xunit;
using QuestionsList.Infrastructure.PgEntities.Questions;
using QuestionsList.Infrastructure.PgEntities.Tags;
using Newtonsoft.Json;

namespace QuestionsList.Infrastructure.Test
{
    public class QuestionUnitTests
    {
        private readonly string _connectionString = "Server=localhost;Port=5432;Database=questions_list;User Id=postgres;Password=postgres;";

        [Fact]
        public void Test1()
        {
            var tags = new PgTags(_connectionString);
            var firstTagId = tags.Add("tag_1").Result;
            var secondTagId = tags.Add("tag_2").Result;
            var questions = new PgQuestions(_connectionString);
            var questionId = questions.Add("question_title", "question_answer", new[] { firstTagId, secondTagId }).Result;
            var question = new PgQuestion(questionId, _connectionString);
            var json = question.JSON().Result;
            dynamic deserializedQuestion = JsonConvert.DeserializeObject(json);
            Assert.True(deserializedQuestion.title == "question_title");
        }
    }
}
