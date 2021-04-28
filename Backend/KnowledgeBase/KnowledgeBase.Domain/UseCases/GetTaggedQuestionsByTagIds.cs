using KnowledgeBase.Domain.Entities;
using SharedKernel;

namespace KnowledgeBase.Domain.UseCases.GetTaggedQuestionsByTagIds
{
    public enum Modes { Intersection, Union }

    public class Request
    {
        public int[] Identifiers { get; set; }
        public Modes Mode { get; set; } = Modes.Intersection;
    }

    public class Response
    {
        public TaggedQuestion[] Questions { get; set; }
    }

    public interface IHandler : IAsyncRequestHandler<Request, Response> { }
}