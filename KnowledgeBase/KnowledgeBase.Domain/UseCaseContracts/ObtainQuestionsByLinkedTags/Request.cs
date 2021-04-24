using System.Collections.Generic;

namespace KnowledgeBase.Domain.UseCaseContracts.ObtainQuestionsByLinkedTags
{
    public class Request
    {
        public Dictionary<string, string[]> Source { get; set; }
    }
}