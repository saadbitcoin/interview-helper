using SharedKernel;

namespace KnowledgeBase.Domain.UseCaseContracts.ObtainQuestionsByLinkedTags
{
    public class Request
    {
        public string TagName { get; set; }
        public string[] Values { get; set; }
    }

    public class Response
    {
        public Question[] Result { get; set; }
    }

    public interface ObtainQuestionsByLinkedTagsUseCaseHandler : UseCaseHandler<Request, Response> { }
}