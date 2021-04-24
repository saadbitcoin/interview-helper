using System.Collections.Generic;

namespace KnowledgeBase.Domain.UseCaseContracts.WithdrawTagsFromQuestion
{
    public class Request
    {
        public int QuestionId { get; set; }
        public string TagTitle { get; set; }
        public List<string> TagValues { get; set; }
    }
}