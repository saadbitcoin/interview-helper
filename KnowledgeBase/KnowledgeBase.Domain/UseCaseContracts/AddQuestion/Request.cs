using System.Collections.Generic;

namespace KnowledgeBase.Domain.UseCaseContracts.AddQuestion
{
    public class Request
    {
        public string Title { get; set; }
        public string Answer { get; set; }
        public Dictionary<string, List<string>> InitialTags { get; set; }
    }
}