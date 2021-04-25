using System.Threading.Tasks;
using AutoMapper;
using KnowledgeBase.Application.UseCaseHandlers;
using KnowledgeBase.Domain;
using KnowledgeBase.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

using AddQuestionUseCase = KnowledgeBase.Domain.UseCaseContracts.AddQuestion;
using ObtainQuestionByIdentifierUseCase = KnowledgeBase.Domain.UseCaseContracts.ObtainQuestionByIdentifier;
using ObtainQuestionsByLinkedTagsUseCase = KnowledgeBase.Domain.UseCaseContracts.ObtainQuestionsByLinkedTags;


namespace KnowledgeBase.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AddQuestionHandler _addQuestionHandler;
        private readonly ObtainQuestionByIdentifierHandler _obtainQuestionByIdentifierHandler;
        private readonly ObtainQuestionsByLinkedTagsHandler _obtainQuestionsByLinkedTagsHandler;

        public QuestionsController(IMapper mapper, AddQuestionHandler addQuestionHandler,
            ObtainQuestionByIdentifierHandler obtainQuestionByIdentifierHandler,
            ObtainQuestionsByLinkedTagsHandler obtainQuestionsByLinkedTagsHandler)
        {
            _mapper = mapper;
            _addQuestionHandler = addQuestionHandler;
            _obtainQuestionByIdentifierHandler = obtainQuestionByIdentifierHandler;
            _obtainQuestionsByLinkedTagsHandler = obtainQuestionsByLinkedTagsHandler;
        }

        [HttpPost]
        public async Task<ActionResult<AddQuestionResultDTO>> AddQuestion([FromBody] AddQuestionDTO model)
        {
            var handlerRequest = _mapper.Map<AddQuestionUseCase.Request>(model);
            var handlerResponse = await _addQuestionHandler.Handle(handlerRequest);
            var resultDTO = _mapper.Map<AddQuestionResultDTO>(handlerResponse);

            return Ok(resultDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion([FromRoute] int id)
        {
            var handlerRequest = _mapper.Map<ObtainQuestionByIdentifierUseCase.Request>(id);
            var handlerResponse = await _obtainQuestionByIdentifierHandler.Handle(handlerRequest);
            var question = handlerResponse.Result;

            return Ok(question);
        }

        [HttpGet("byLinkedTags/{tag}")]
        public async Task<ActionResult<Question[]>> GetQuestionsByLinkedTag([FromRoute] string tag, [FromHeader(Name = "x-tag-values")] string[] tagValues)
        {
            var handlerRequest = new ObtainQuestionsByLinkedTagsUseCase.Request { TagName = tag, Values = tagValues };
            var handlerResponse = await _obtainQuestionsByLinkedTagsHandler.Handle(handlerRequest);
            var accordingQuestions = handlerResponse.Result;

            return Ok(accordingQuestions);
        }
    }
}