using SharedKernel;

namespace KnowledgeBase.Infrastructure.DataAccess.Models
{
    public class QuestionTableRepresentation : IdentifiedEntity
    {
        public string Title { get; set; }
        public string Answer { get; set; }
    }
}