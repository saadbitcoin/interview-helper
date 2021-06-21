using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QuestionsList.Infrastructure.Entities.Tags;
using MicroserviceHandlers.Contracts.QuestionsList;

namespace QuestionsList.API.Controllers
{
    [ApiController]
    [Route("tags")]
    public sealed class TagsController : ControllerBase
    {
        private readonly string _pgConnectionString;

        public TagsController(IConfiguration configuration)
        {
            _pgConnectionString = configuration.GetConnectionString("Postgres");
        }

        [HttpGet]
        public async Task<ActionResult<TagSchema[]>> GetAll()
        {
            var tags = new PgTags(_pgConnectionString);
            try
            {
                var tagElements = await tags.Elements();
                var tagElementsData = await Task.WhenAll(tagElements.Select(x => x.SerializableState()));
                return Ok(tagElementsData);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<TagCreationResponseModel>> Add([FromBody] TagCreationRequestModel request)
        {
            var tags = new PgTags(_pgConnectionString);
            try
            {
                var newTagId = await tags.Add(request.title);
                return StatusCode(StatusCodes.Status201Created, new TagCreationResponseModel(newTagId));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}