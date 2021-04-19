using SharedKernel;

namespace KnowledgeBase.Domain
{
    public class LinkedTag : IdentifiedEntity
    {
        public Tag Tag { get; set; }
        public string Value { get; set; }
    }
}