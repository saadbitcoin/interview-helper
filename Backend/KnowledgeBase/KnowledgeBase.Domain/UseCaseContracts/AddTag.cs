using System.Collections.Generic;
using SharedKernel;

namespace KnowledgeBase.Domain.UseCaseContracts.AddTag
{
    public class Request
    {
        public string Title { get; set; }
        public List<string> InitialValues { get; set; }
    }

    public class Response
    {
        public int TagId { get; set; }
    }

    public interface AddTagUseCaseHandler : UseCaseHandler<Request, Response> { }
}