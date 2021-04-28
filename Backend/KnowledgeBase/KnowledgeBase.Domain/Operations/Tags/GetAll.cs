using KnowledgeBase.Domain.Entities.Base;
using SharedKernel;

namespace KnowledgeBase.Domain.Operations.Tags.GetAll
{
    public class Request
    {

    }

    public class Response
    {
        public Tag[] Tags { get; set; }
    }

    public interface IHandler : IAsyncRequestHandler<Request, Response> { }
}