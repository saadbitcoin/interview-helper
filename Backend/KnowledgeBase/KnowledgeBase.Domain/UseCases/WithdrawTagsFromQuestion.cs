using SharedKernel;

namespace KnowledgeBase.Domain.UseCases.WithdrawTagsFromQuestion
{
    public class Request
    {
        public int QuestionId { get; set; }
        public int[] TagIds { get; set; }
    }

    public class Response
    {
        public int WithdrawnTagsCount { get; set; }
    }

    public interface IHandler : IAsyncRequestHandler<Request, Response> { }
}