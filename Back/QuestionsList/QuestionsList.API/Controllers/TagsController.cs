using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using QuestionsList.Infrastructure.PgEntities.Tags;
using SharedKernel.JSON;

namespace QuestionsList.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class TagsController : ControllerBase
    {
        private readonly string _pgConnectionString;

        public TagsController(IConfiguration configuration)
        {
            _pgConnectionString = configuration.GetConnectionString("Postgres");
        }

        /// <summary>
        /// Adds new tag if a tag with provided name was not existing.
        /// </summary>
        /// <param name="request">JObject of schema {"title": string}</param>
        /// <example>
        /// curl -i -H "Content-Type: application/json" -X POST -d '{"title":"new_title"}' http://localhost:5000/tags
        /// </example>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] JObject request)
        {
            var title = request.Value<string>("title");
            if (string.IsNullOrEmpty(title))
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Title was not provided");
            }
            var tags = new PgTags(_pgConnectionString);
            try
            {
                var newTagId = await tags.Add(title);
                return StatusCode(StatusCodes.Status201Created, newTagId);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Returns collection of all questions.
        /// </summary>
        /// <example>
        /// curl -i -X GET http://localhost:5000/tags
        /// </example>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tags = new PgTags(_pgConnectionString);
            try
            {
                var tagElements = await tags.Elements();
                var tagElementsJSONArray = new JSONArrayAsync(tagElements);
                var tagsInJSON = await tagElementsJSONArray.JSON();
                return StatusCode(StatusCodes.Status200OK, tagsInJSON);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}