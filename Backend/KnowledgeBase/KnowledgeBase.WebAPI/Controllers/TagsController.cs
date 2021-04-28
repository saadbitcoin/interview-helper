using System.Threading.Tasks;
using AutoMapper;
using KnowledgeBase.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Operations = KnowledgeBase.Domain.Operations;

namespace KnowledgeBase.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagsController : ControllerBase
    {
        private IMapper _mapper;
        private readonly Operations.Tags.Create.IHandler _createTagHandler;
        private readonly Operations.Tags.GetAll.IHandler _getAllTagsHandler;

        public TagsController(IMapper mapper, Operations.Tags.Create.IHandler createTagHandler,
            Operations.Tags.GetAll.IHandler getAllTagsHandler)
        {
            _mapper = mapper;
            _createTagHandler = createTagHandler;
            _getAllTagsHandler = getAllTagsHandler;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateTagDTO model)
        {
            var request = _mapper.Map<Operations.Tags.Create.Request>(model);
            var response = await _createTagHandler.Handle(request);
            if (!response.Success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok();
        }

        [HttpGet("all")]
        public async Task<ActionResult<GetTagsDTO>> GetAll()
        {
            var request = new Operations.Tags.GetAll.Request { };
            var response = await _getAllTagsHandler.Handle(request);
            return Ok(response);
        }
    }
}