using System.Threading.Tasks;
using AutoMapper;
using KnowledgeBase.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UseCases = KnowledgeBase.Domain.UseCases;
namespace KnowledgeBase.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UseCases.CreateLinkedQuestionFromScratch.IHandler _createLinkedQuestionFromScratch;
        private readonly UseCases.GetTaggedQuestionsByTagIds.IHandler _getTaggedQuestionsByTagIds;

        public QuestionsController(IMapper mapper,
            UseCases.GetTaggedQuestionByQuestionId.IHandler getTaggedQuestionByQuestionId,
            UseCases.CreateLinkedQuestionFromScratch.IHandler createLinkedQuestionFromScratch,
            UseCases.GetTaggedQuestionsByTagIds.IHandler getTaggedQuestionsByTagIds)
        {
            _mapper = mapper;
            _createLinkedQuestionFromScratch = createLinkedQuestionFromScratch;
            _getTaggedQuestionsByTagIds = getTaggedQuestionsByTagIds;
        }

        [HttpPost]
        public async Task<ActionResult<CreateQuestionResultDTO>> Create([FromBody] CreateQuestionDTO model)
        {
            var request = _mapper.Map<UseCases.CreateLinkedQuestionFromScratch.Request>(model);
            var response = await _createLinkedQuestionFromScratch.Handle(request);
            if (!response.Success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var resultDTO = _mapper.Map<CreateQuestionResultDTO>(response);
            return Ok(resultDTO);
        }

        [HttpGet("byTagsIntersection")]
        public async Task<ActionResult<GetQuestionsDTO>> GetByTagsIntersection([FromQuery] int[] tagIds)
        {
            var request = new UseCases.GetTaggedQuestionsByTagIds.Request
            {
                Identifiers = tagIds,
                Mode = UseCases.GetTaggedQuestionsByTagIds.Modes.Intersection
            };
            var response = await _getTaggedQuestionsByTagIds.Handle(request);
            var resultDTO = _mapper.Map<GetQuestionsDTO>(response);
            return Ok(resultDTO);
        }

        [HttpGet("byTagsUnion")]
        public async Task<ActionResult<GetQuestionsDTO>> GetByTagsUnion([FromQuery] int[] tagIds)
        {
            var request = new UseCases.GetTaggedQuestionsByTagIds.Request
            {
                Identifiers = tagIds,
                Mode = UseCases.GetTaggedQuestionsByTagIds.Modes.Union
            };
            var response = await _getTaggedQuestionsByTagIds.Handle(request);
            var resultDTO = _mapper.Map<GetQuestionsDTO>(response);
            return Ok(resultDTO);
        }
    }
}