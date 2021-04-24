using SharedKernel;

namespace KnowledgeBase.Infrastructure.DataAccess.Models
{
    public class QuestionLinkedTag : IdentifiedEntity
    {
        public int QuestionId { get; set; }
        public int LinkedTagId { get; set; }
    }
}