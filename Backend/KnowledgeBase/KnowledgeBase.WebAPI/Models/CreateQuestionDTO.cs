namespace KnowledgeBase.WebAPI.Models
{
    public class CreateQuestionDTO
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public string[] AccordingTags { get; set; }
    }
}