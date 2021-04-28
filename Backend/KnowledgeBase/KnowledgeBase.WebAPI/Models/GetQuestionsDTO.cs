using KnowledgeBase.Domain.Entities;

namespace KnowledgeBase.WebAPI.Models
{
    public class GetQuestionsDTO
    {
        public TaggedQuestion[] Questions { get; set; }
    }
}