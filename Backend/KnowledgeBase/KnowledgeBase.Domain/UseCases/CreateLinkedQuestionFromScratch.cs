using SharedKernel;

namespace KnowledgeBase.Domain.UseCases.CreateLinkedQuestionFromScratch
{
    public class Request
    {
        public string Title { get; set; }
        public string Answer { get; set; }
        public string[] Tags { get; set; }
    }

    public class Response
    {
        public int? LinkedQuestionIdentifier { get; set; }
        public bool Success { get; set; }
    }

    public interface IHandler : IAsyncRequestHandler<Request, Response> { }
}