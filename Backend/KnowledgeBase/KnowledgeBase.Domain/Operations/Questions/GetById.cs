using SharedKernel;
using KnowledgeBase.Domain.Entities.Base;

namespace KnowledgeBase.Domain.Operations.Questions.GetById
{
    public class Request
    {
        public int QuestionIdentifier { get; set; }
    }

    public class Response
    {
        public Question Question { get; set; }
        public bool IsFound { get; set; }
    }

    public interface IHandler : IAsyncRequestHandler<Request, Response> { }
}