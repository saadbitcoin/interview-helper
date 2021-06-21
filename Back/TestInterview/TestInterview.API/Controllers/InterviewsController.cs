using System.Linq;
using System.Threading.Tasks;
using MicroserviceHandlers.WebAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TestInterview.Core.Schemas;
using TestInterview.Infrastructure.Entities.Interviews;

namespace TestInterview.API.Controllers
{
    [ApiController]
    [Route("interviews")]
    public sealed class InterviewsController : ControllerBase
    {
        private readonly string _pgConnectionString;
        private readonly string _questionsListMicroserviceEndpoint;

        public InterviewsController(IConfiguration configuration)
        {
            _pgConnectionString = configuration.GetConnectionString("Postgres");
            _questionsListMicroserviceEndpoint = configuration.GetConnectionString("QuestionsListMicroservice");

        }

        [HttpGet("byTemplateId/{templateId}")]
        public async Task<ActionResult<InterviewSchema>> GetQuestionsByTemplateId(int templateId)
        {
            var microserviceHandler = new QuestionsListWebAPIHandler(_questionsListMicroserviceEndpoint);
            var interview = new PgPartialInterview(_pgConnectionString, templateId, microserviceHandler);
            var questions = await interview.Questions();
            var questionStates = await Task.WhenAll(questions.Select(x => x.SerializableState()));
            var interviewState = new InterviewSchema(questionStates);

            return Ok(interviewState);
        }
    }
}