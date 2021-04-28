using KnowledgeBase.Domain.Entities.Base;

namespace KnowledgeBase.Domain.Entities
{
    public class TaggedQuestion : Question
    {
        public Tag[] Tags { get; set; }
    }
}