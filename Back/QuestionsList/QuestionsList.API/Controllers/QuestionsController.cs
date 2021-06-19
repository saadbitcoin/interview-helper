using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QuestionsList.Infrastructure.Entities.Questions;
using SharedKernel.HTTPRouteObjects;
using MicroserviceHandlers.Contracts.QuestionsList;
using QuestionsList.API.Extenstions;

namespace QuestionsList.API.Controllers
{
    [ApiController]
    [Route("questions")]
    public class QuestionsController : ControllerBase
    {
        private readonly string _pgConnectionString;

        public QuestionsController(IConfiguration configuration)
        {
            _pgConnectionString = configuration.GetConnectionString("Postgres");
        }

        [HttpGet("recentlyAdded")]
        public async Task<ActionResult<QuestionWithTagSchema[]>> GetRecentlyAdded([FromQuery] int count)
        {
            var questions = new PgQuestions(_pgConnectionString);
            var result = await questions.LastAdded(count);
            var questionStates = await Task.WhenAll(result.Select(x => x.ToFullDTO()));

            return Ok(questionStates);
        }

        [HttpGet("unionTagged/{tagIdsRequest}")]
        public async Task<ActionResult<QuestionWithTagSchema[]>> GetByTagsUnion([FromRoute] string tagIdsRequest)
        {
            var tagIdsRouteArray = new HTTPRouteArray<int>(tagIdsRequest, int.Parse);
            var tagIds = tagIdsRouteArray.Result;
            if (tagIds.Length == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Tag identifiers were not provided");
            }
            var unionTaggedQuestions = new PgUnionTaggedQuestionSelection(tagIds, _pgConnectionString);
            var questions = await unionTaggedQuestions.Elements();
            var questionsData = await Task.WhenAll(questions.Select(x => x.ToFullDTO()));

            return Ok(questionsData);
        }

        [HttpPost]
        public async Task<ActionResult<QuestionCreationResponseModel>> Create([FromBody] QuestionCreationRequestModel request)
        {
            if (request.tagIds.Length == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Tag identifiers were not provided");
            }

            var questions = new PgQuestions(_pgConnectionString);
            try
            {
                var newQuestionId = await questions.Add(request.title, request.answer, request.tagIds);

                return StatusCode(StatusCodes.Status201Created, new QuestionCreationResponseModel(newQuestionId));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("randomQuestionsByTag")]
        public async Task<ActionResult<QuestionWithTagSchema[]>> GetRandomQuestionsByTag([FromQuery] int tagId, [FromQuery] int count)
        {
            var requiredQuestionsSelection = new PgTagRandomQuestions(_pgConnectionString, tagId);
            var questions = await requiredQuestionsSelection.RandomElements(count);
            var questionsData = await Task.WhenAll(questions.Select(x => x.ToFullDTO()));

            return Ok(questionsData);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionWithTagSchema>> GetById([FromRoute] int id)
        {
            var question = new PgQuestion(id, _pgConnectionString);
            var questionData = await question.ToFullDTO();

            return Ok(questionData);
        }
    }
}
