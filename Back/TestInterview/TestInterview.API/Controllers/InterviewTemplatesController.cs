using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TestInterview.Core.Schemas;
using TestInterview.Infrastructure.Entities.InterviewTemplates;

namespace TestInterview.API.Controllers
{
    [ApiController]
    [Route("interviewTemplates")]
    public sealed class InterviewTemplatesController : ControllerBase
    {
        private readonly string _pgConnectionString;

        public InterviewTemplatesController(IConfiguration configuration)
        {
            _pgConnectionString = configuration.GetConnectionString("Postgres");
        }

        [HttpPost]
        public async Task<ActionResult<InterviewTemplateCreationResponseModel>> Create([FromBody] InterviewTemplateCreationRequestModel model)
        {
            var pgInterviewTemplates = new PgInterviewTemplates(_pgConnectionString);
            var newTemplateId = await pgInterviewTemplates.Create(
                model.title,
                model.questionData.Select(x => (x.tagId, x.count)
            ).ToArray());

            return Ok(new InterviewTemplateCreationResponseModel(newTemplateId));
        }

        [HttpGet]
        public async Task<ActionResult<InterviewTemplateSchema[]>> GetAll()
        {
            var pgInterviewTemplates = new PgInterviewTemplates(_pgConnectionString);
            var interviewTemplates = await pgInterviewTemplates.Elements();
            var interviewTemplateStates = await Task.WhenAll(interviewTemplates.Select(x => x.SerializableState()));

            return Ok(interviewTemplateStates);
        }

    }
}