using KnowledgeBase.Domain.Entities.Base;

namespace KnowledgeBase.WebAPI.Models
{
    public class GetTagsDTO
    {
        public Tag[] Tags { get; set; }
    }
}