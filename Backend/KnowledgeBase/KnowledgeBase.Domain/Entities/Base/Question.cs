using SharedKernel;

namespace KnowledgeBase.Domain.Entities.Base
{
    public class Question : IdentifiedEntity
    {
        public string Title { get; set; }
        public string Answer { get; set; }
    }
}