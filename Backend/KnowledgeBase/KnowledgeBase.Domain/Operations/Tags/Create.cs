using SharedKernel;

namespace KnowledgeBase.Domain.Operations.Tags.Create
{
    public class Request
    {
        public string Title { get; set; }
    }

    public class Response
    {
        public int? TagIdentifier { get; set; }
        public bool Success { get; set; }
    }

    public interface IHandler : IAsyncRequestHandler<Request, Response> { }
}