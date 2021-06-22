using Xunit;
using QuestionsList.Infrastructure.Entities.Tags;
using System.Linq;

namespace QuestionsList.Infrastructure.Test
{
    [Collection("Question list tests")]
    public class PgTagsUnitTests
    {
        private PgTags tags = new PgTags("Server=localhost;Port=5432;Database=questions_list_test;User Id=postgres;Password=postgres;");

        [Fact]
        public void TagsCountIsIncreasedByOneAfterTagCreation()
        {
            var count = tags.Elements().Result.Length;
            var newTagId = tags.Add(System.Guid.NewGuid().ToString()).Result;
            var newCount = tags.Elements().Result.Length;

            Assert.Equal<int>(newCount, count + 1);
        }

        [Fact]
        public void CreatedTagIsInList()
        {
            var _randomTagTitle = System.Guid.NewGuid().ToString();
            var newTagId = tags.Add(_randomTagTitle).Result;
            var tagElements = tags.Elements().Result;
            var tagStates = tagElements.Select(x => x.SerializableState().Result);

            Assert.Contains(tagStates, x => x.title == _randomTagTitle);
        }
    }
}
