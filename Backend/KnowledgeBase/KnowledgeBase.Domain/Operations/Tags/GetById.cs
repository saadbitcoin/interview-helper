using KnowledgeBase.Domain.Entities.Base;
using SharedKernel;

namespace KnowledgeBase.Domain.Operations.Tags.GetById
{
    public class Request
    {
        public int TagIdentifier { get; set; }
    }

    public class Response
    {
        public Tag Tag { get; set; }
        public bool IsFound { get; set; }
    }

    public interface IHandler : IAsyncRequestHandler<Request, Response> { }
}