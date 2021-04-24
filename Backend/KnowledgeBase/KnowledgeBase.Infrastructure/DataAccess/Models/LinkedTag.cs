using SharedKernel;

namespace KnowledgeBase.Infrastructure.DataAccess.Models
{
    public class LinkedTag : IdentifiedEntity
    {
        public int TagId { get; set; }
        public string Value { get; set; }
    }
}