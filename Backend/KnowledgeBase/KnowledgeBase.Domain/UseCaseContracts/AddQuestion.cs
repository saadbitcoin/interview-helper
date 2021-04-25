using System.Collections.Generic;
using SharedKernel;

namespace KnowledgeBase.Domain.UseCaseContracts.AddQuestion
{
    public class Request
    {
        public string Title { get; set; }
        public string Answer { get; set; }
        public Dictionary<string, List<string>> InitialTags { get; set; }
    }

    public class Response
    {
        public int QuestionId { get; set; }
    }

    public interface AddQuestionUseCaseHandler : UseCaseHandler<Request, Response> { }
}