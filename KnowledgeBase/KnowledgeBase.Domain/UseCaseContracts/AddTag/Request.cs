using System.Collections.Generic;

namespace KnowledgeBase.Domain.UseCaseContracts.AddTag
{
    public class Request
    {
        public string Title { get; set; }
        public List<string> InitialValues { get; set; }
    }
}