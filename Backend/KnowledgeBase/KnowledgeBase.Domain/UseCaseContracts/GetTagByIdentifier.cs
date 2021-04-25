using SharedKernel;

namespace KnowledgeBase.Domain.UseCaseContracts.GetTagByIdentifier
{
    public class Request
    {
        public int TagId { get; set; }
    }

    public class Response
    {
        public Tag RequiredTag { get; set; }
    }

    public interface GetTagByIdentifierUseCaseHandler : UseCaseHandler<Request, Response> { }
}