using SharedKernel;

namespace KnowledgeBase.Domain.UseCaseContracts.GetAllTagBasicInfo
{
    public class BasicTagInfo : IdentifiedEntity
    {
        public string Name { get; set; }
    }

    public class Request
    {

    }

    public class Response
    {
        public BasicTagInfo[] Items { get; set; }
    }

    public interface GetAllTagBasicInfoUseCaseHandler : UseCaseHandler<Request, Response> { }
}