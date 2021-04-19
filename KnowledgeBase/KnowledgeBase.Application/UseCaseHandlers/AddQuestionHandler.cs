using SharedKernel;
using KnowledgeBase.Domain.UseCaseContracts.AddQuestion;
using System.Threading.Tasks;
using KnowledgeBase.Application.Repositories;

namespace KnowledgeBase.Application.UseCaseHandlers
{
    public class AddQuestionHandler : UseCaseHandler<Request, Response>
    {
        private readonly IQuestionsRepository _questionsRepository;

        public AddQuestionHandler(IQuestionsRepository questionsRepository)
        {
            _questionsRepository = questionsRepository;
        }

        public async Task<Response> Handle(Request requestData)
        {
            var newQuestionId = await _questionsRepository.AddQuestion(requestData.Data);

            return new Response { QuestionId = newQuestionId };
        }
    }
}