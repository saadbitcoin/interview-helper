using System.Collections.Generic;

namespace KnowledgeBase.WebAPI.Models
{
    public class AddQuestionDTO
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public Dictionary<string, List<string>> Tags { get; set; }
    }
}