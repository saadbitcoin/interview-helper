using SharedKernel;

namespace KnowledgeBase.Domain
{
    public class Question : IdentifiedEntity
    {
        public string Title { get; set; }
        public string Answer { get; set; }
        public LinkedTag[] LinkedTags { get; set; }
    }
}