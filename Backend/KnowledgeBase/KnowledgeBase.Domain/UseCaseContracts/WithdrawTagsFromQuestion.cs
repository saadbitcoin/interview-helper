using System.Collections.Generic;
using SharedKernel;

namespace KnowledgeBase.Domain.UseCaseContracts.WithdrawTagsFromQuestion
{
    public class Request
    {
        public int QuestionId { get; set; }
        public string TagTitle { get; set; }
        public List<string> TagValues { get; set; }
    }

    public class Response
    {
        public int WithdrawnLinkedTagsCount { get; set; }
    }

    public interface WithdrawTagsFromQuestionUseCaseHandler : UseCaseHandler<Request, Response> { }
}