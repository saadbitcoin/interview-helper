using SharedKernel;

namespace KnowledgeBase.Domain
{
    public class Tag : IdentifiedEntity
    {
        public string Title { get; set; }
        public string[] PossibleValues { get; set; }
    }
}