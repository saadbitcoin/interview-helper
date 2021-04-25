using System.Collections.Generic;
using SharedKernel;

namespace KnowledgeBase.Domain.UseCaseContracts.LinkNewTagsToQuestion
{
    public class Request
    {
        public int QuestionId { get; set; }
        public string TagTitle { get; set; }
        public List<string> TagValues { get; set; }
    }

    public class Response
    {
        public int CreatedTagsCount { get; set; }
        public int ExistedTagsCount { get; set; }
        public int TotalLinkedTagsCount => CreatedTagsCount + ExistedTagsCount;
    }

    public interface LinkNewTagsToQuestionUseCaseHandler : UseCaseHandler<Request, Response> { }
}