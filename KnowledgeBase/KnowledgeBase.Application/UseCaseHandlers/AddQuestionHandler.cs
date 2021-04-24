using SharedKernel;
using KnowledgeBase.Domain.UseCaseContracts.AddQuestion;
using System.Threading.Tasks;
using KnowledgeBase.Application.Repositories;
using KnowledgeBase.Domain;

namespace KnowledgeBase.Application.UseCaseHandlers
{
    public class AddQuestionHandler : UseCaseHandler<Request, Response>
    {
        private readonly IQuestionsRepository _questionsRepository;
        private readonly ITagsRepository _tagsRepository;

        public AddQuestionHandler(IQuestionsRepository questionsRepository, ITagsRepository tagsRepository)
        {
            _questionsRepository = questionsRepository;
            _tagsRepository = tagsRepository;
        }

        public async Task<Response> Handle(Request requestData)
        {
            var newQuestion = new Question
            {
                Answer = requestData.Answer,
                Title = requestData.Title,
                TagsInformation = requestData.InitialTags
            };

            var newQuestionId = await _questionsRepository.AddQuestion(newQuestion);

            return new Response { QuestionId = newQuestionId };
        }
    }
}