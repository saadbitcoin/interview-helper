using System.Threading.Tasks;
using KnowledgeBase.Application.UseCaseHandlers;
using Microsoft.AspNetCore.Mvc;
using GetAllTagBasicInfoUseCase = KnowledgeBase.Domain.UseCaseContracts.GetAllTagBasicInfo;

namespace KnowledgeBase.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagsController : ControllerBase
    {
        private readonly GetAllTagBasicInfoHandler _getAllTagBasicInfoHandler;

        public TagsController(GetAllTagBasicInfoHandler getAllTagBasicInfoHandler)
        {
            _getAllTagBasicInfoHandler = getAllTagBasicInfoHandler;
        }

        [HttpGet("basicInfo")]
        public async Task<ActionResult<GetAllTagBasicInfoUseCase.BasicTagInfo[]>> GetAllTagsBasicInfo()
        {
            var result = await _getAllTagBasicInfoHandler.Handle(new GetAllTagBasicInfoUseCase.Request());

            return Ok(result.Items);
        }
    }
}