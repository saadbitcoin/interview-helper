using SharedKernel;

namespace KnowledgeBase.Domain.UseCaseContracts.ObtainQuestionByIdentifier
{
    public class Request
    {
        public int QuestionIdentifier { get; set; }
    }

    public class Response
    {
        public Question Result { get; set; }
    }

    public interface ObtainQuestionByIdentifierUseCaseHandler : UseCaseHandler<Request, Response> { }
}