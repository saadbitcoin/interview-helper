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
        public int CreatedTagsCount { get; set; }
        public int ExistedTagsCount { get; set; }
        public int TotalLinkedTagsCount => CreatedTagsCount + ExistedTagsCount;
    }

    public interface LinkNewTagToQuestionUseCaseHandler : UseCaseHandler<Request, Response> { }
}