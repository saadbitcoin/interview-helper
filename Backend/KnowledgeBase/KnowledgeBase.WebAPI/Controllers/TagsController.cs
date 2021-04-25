using System.Threading.Tasks;
using KnowledgeBase.Application.UseCaseHandlers;
using KnowledgeBase.Domain;
using KnowledgeBase.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using GetAllTagBasicInfoUseCase = KnowledgeBase.Domain.UseCaseContracts.GetAllTagBasicInfo;
using GetTagByIdentifier = KnowledgeBase.Domain.UseCaseContracts.GetTagByIdentifier;

namespace KnowledgeBase.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagsController : ControllerBase
    {
        private readonly GetAllTagBasicInfoHandler _getAllTagBasicInfoHandler;
        private readonly GetTagByIdentifierHandler _getTagByIdentifierHandler;

        public TagsController(GetAllTagBasicInfoHandler getAllTagBasicInfoHandler,
            GetTagByIdentifierHandler getTagByIdentifierHandler)
        {
            _getAllTagBasicInfoHandler = getAllTagBasicInfoHandler;
            _getTagByIdentifierHandler = getTagByIdentifierHandler;
        }

        [HttpGet("basicInfo")]
        public async Task<ActionResult<GetAllTagBasicInfoUseCase.BasicTagInfo[]>> GetAllTagsBasicInfo()
        {
            var handlerResponse = await _getAllTagBasicInfoHandler.Handle(new GetAllTagBasicInfoUseCase.Request());

            return Ok(handlerResponse.Items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetTagByIdDTO>> GetTag([FromRoute] int id)
        {
            var handlerResponse = await _getTagByIdentifierHandler.Handle(new GetTagByIdentifier.Request { TagId = id });

            return Ok(new GetTagByIdDTO { Data = handlerResponse.RequiredTag });
        }
    }
}