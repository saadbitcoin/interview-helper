using System.Threading.Tasks;
using AutoMapper;
using KnowledgeBase.Application.UseCaseHandlers;
using KnowledgeBase.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

using AddQuestionUseCase = KnowledgeBase.Domain.UseCaseContracts.AddQuestion;
using ObtainQuestionByIdentifierUseCase = KnowledgeBase.Domain.UseCaseContracts.ObtainQuestionByIdentifier;


namespace KnowledgeBase.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AddQuestionHandler _addQuestionHandler;
        private readonly ObtainQuestionByIdentifierHandler _obtainQuestionByIdentifierHandler;

        public QuestionsController(IMapper mapper, AddQuestionHandler addQuestionHandler,
            ObtainQuestionByIdentifierHandler obtainQuestionByIdentifierHandler)
        {
            _mapper = mapper;
            _addQuestionHandler = addQuestionHandler;
            _obtainQuestionByIdentifierHandler = obtainQuestionByIdentifierHandler;
        }

        [HttpPost]
        public async Task<ActionResult<AddQuestionResultDTO>> AddQuestion(AddQuestionDTO model)
        {
            var handlerRequest = _mapper.Map<AddQuestionUseCase.Request>(model);
            var result = await _addQuestionHandler.Handle(handlerRequest);
            var resultDTO = _mapper.Map<AddQuestionResultDTO>(result);

            return Ok(resultDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetQuestion([FromRoute] int id)
        {
            var handlerRequest = _mapper.Map<ObtainQuestionByIdentifierUseCase.Request>(id);
            var result = await _obtainQuestionByIdentifierHandler.Handle(handlerRequest);

            return Ok(result);
        }
    }
}