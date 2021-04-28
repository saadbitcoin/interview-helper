using SharedKernel;

namespace KnowledgeBase.Domain.UseCases.LinkTagsToQuestion
{
    public class Request
    {
        public int QuestionId { get; set; }
        public int[] TagIds { get; set; }
    }

    public class Response
    {
        public int LinkedTagsCount { get; set; }
    }

    public interface IHandler : IAsyncRequestHandler<Request, Response> { }
}