using SharedKernel;

namespace KnowledgeBase.Domain.Operations.Questions.Create
{
    public class Request
    {
        public string Title { get; set; }
        public string Answer { get; set; }
    }

    public class Response
    {
        public int? QuestionIdentifier { get; set; }
        public bool Success { get; set; }
    }

    public interface IHandler : IAsyncRequestHandler<Request, Response> { }
}