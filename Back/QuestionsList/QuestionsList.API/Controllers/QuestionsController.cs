using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using QuestionsList.Infrastructure.PgEntities.Questions;
using SharedKernel.JSON;
using SharedKernel.HTTPRouteObjects;

namespace QuestionsList.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly string _pgConnectionString;

        public QuestionsController(IConfiguration configuration)
        {
            _pgConnectionString = configuration.GetConnectionString("Postgres");
        }

        /// <summary>
        /// Returns recently added questions.
        /// </summary>
        /// <param name="count">Required questions count</param>
        /// <example>
        /// curl -i -X GET http://localhost:5000/questions/recentlyAdded?count=10
        /// </example>
        [HttpGet("recentlyAdded")]
        public async Task<IActionResult> GetRecentlyAdded([FromQuery] int count)
        {
            var questions = new PgQuestions(_pgConnectionString);
            var result = await questions.LastAdded(count);
            var resultJSONArray = new JSONArrayAsync(result);
            var resultJSON = await resultJSONArray.JSON();
            return StatusCode(StatusCodes.Status200OK, resultJSON);
        }

        /// <summary>
        /// Returns union tagged questions.
        /// </summary>
        /// <param name="tagIdsRequest">Required tag ids separated by ","</param>
        /// <example>
        /// curl -i -X GET http://localhost:5000/questions/unionTagged/1,3,5
        /// </example>
        [HttpGet("unionTagged/{tagIdsRequest}")]
        public async Task<IActionResult> GetByTagsUnion([FromRoute] string tagIdsRequest)
        {
            var tagIdsRouteArray = new HTTPRouteArray<int>(tagIdsRequest, int.Parse);
            var tagIds = tagIdsRouteArray.Result;
            if (tagIds.Length == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Tag identifiers were not provided");
            }
            var unionTaggedQuestions = new PgUnionTaggedQuestionSelection(tagIds, _pgConnectionString);
            var questions = await unionTaggedQuestions.Elements();
            var questionsJSONArray = new JSONArrayAsync(questions);
            var questionsAsJSON = await questionsJSONArray.JSON();
            return StatusCode(StatusCodes.Status200OK, questionsAsJSON);
        }

        /// <summary>
        /// Creates a new question.
        /// </summary>
        /// <param name="request">JObject of {"title": string, "answer": string, "tagIds": number[]}</param>
        /// <example>
        /// curl -i -H "Content-Type: application/json" -X POST -d '{"title": "1", "answer": "2", "tagIds": [4,5]}' http://localhost:5000/questions
        /// </example>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] JObject request)
        {
            var title = request.Value<string>("title");
            if (string.IsNullOrEmpty(title))
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Title was not provided");
            }
            var answer = request.Value<string>("answer");
            if (string.IsNullOrEmpty(answer))
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Answer was not provided");
            }
            var tagIds = request.Value<JArray>("tagIds").Values<int>().ToArray();
            if (tagIds.Length == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Tag identifiers were not provided");
            }
            var questions = new PgQuestions(_pgConnectionString);
            try
            {
                var newQuestionId = await questions.Add(title, answer, tagIds);
                return StatusCode(StatusCodes.Status201Created, newQuestionId);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Returns selection of given size of given tag random questions.
        /// </summary>
        /// <param name="tagId">Required tag identifier</param>
        /// <param name="count">Selection size</param>
        /// <example>
        /// curl -i -X GET "http://localhost:5000/questions/randomQuestionsByTag?tagId=1&count=5"
        /// </example>
        [HttpGet("randomQuestionsByTag")]
        public async Task<IActionResult> GetRandomQuestionsByTag([FromQuery] int tagId, [FromQuery] int count)
        {
            var requiredQuestionsSelection = new PgTaggedRandomQuestions(_pgConnectionString, tagId);
            var questions = await requiredQuestionsSelection.RandomElements(count);
            var questionsJSONArray = new JSONArrayAsync(questions);
            var questionsAsJSON = await questionsJSONArray.JSON();

            return Ok(questionsAsJSON);
        }

        /// <summary>
        /// Returns full question info by question identifier,
        /// </summary>
        /// <param name="id">Required question id</param>
        /// <example>
        /// curl -i -X GET http://localhost:5000/questions/5
        /// </example>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var question = new PgQuestion(id, _pgConnectionString);
            var jsonRepresentation = await question.JSON();

            return Ok(jsonRepresentation);
        }
    }
}
