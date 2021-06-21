using System.Linq;
using System.Threading.Tasks;
using MicroserviceHandlers.Contracts.QuestionsList;
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
        private readonly IQuestionsListMicroservice _questionsListMicroservice;

        public InterviewsController(IConfiguration configuration)
        {
            _questionsListMicroservice = new QuestionsListWebAPIHandler(
                configuration.GetConnectionString("QuestionsListMicroservice")
            );
            _pgConnectionString = configuration.GetConnectionString("Postgres");
        }

        [HttpGet("generateByTemplateId/{templateId}")]
        public async Task<ActionResult<InterviewSchema>> GenerateByTemplateId(int templateId)
        {
            var interview = new PgPartialInterview(_pgConnectionString, templateId, _questionsListMicroservice);
            var questions = await interview.Questions();

            var questionStates = await Task.WhenAll(questions.Select(x => x.SerializableState()));
            var interviewState = new InterviewSchema(questionStates);

            return Ok(interviewState);
        }
    }
}