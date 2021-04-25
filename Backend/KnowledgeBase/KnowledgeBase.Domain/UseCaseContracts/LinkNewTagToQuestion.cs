using System.Collections.Generic;
using SharedKernel;

namespace KnowledgeBase.Domain.UseCaseContracts.LinkNewTagToQuestion
{
    public class Request
    {
        public int QuestionId { get; set; }
        public string TagTitle { get; set; }
        public List<string> TagValues { get; set; }
    }

    public class Response
    {
        public int AddedLinkedTagsCount { get; set; }
    }

    public interface LinkNewTagToQuestionUseCaseHandler : UseCaseHandler<Request, Response> { }
}