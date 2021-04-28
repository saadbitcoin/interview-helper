using KnowledgeBase.Domain.Entities;
using SharedKernel;

namespace KnowledgeBase.Domain.UseCases.GetTaggedQuestionByQuestionId
{
    public class Request
    {
        public int QuestionId { get; set; }
    }

    public class Response
    {
        public TaggedQuestion TaggedQuestion { get; set; }
        public bool IsFound { get; set; }
    }

    public interface IHandler : IAsyncRequestHandler<Request, Response> { }
}