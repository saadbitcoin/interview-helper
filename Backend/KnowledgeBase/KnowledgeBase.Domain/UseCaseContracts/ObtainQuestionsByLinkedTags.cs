using System.Collections.Generic;
using SharedKernel;

namespace KnowledgeBase.Domain.UseCaseContracts.ObtainQuestionsByLinkedTags
{
    public class Request
    {
        public Dictionary<string, string[]> Source { get; set; }
    }

    public class Response
    {
        public Question[] Result { get; set; }
    }

    public interface ObtainQuestionsByLinkedTagsUseCaseHandler : UseCaseHandler<Request, Response> { }
}