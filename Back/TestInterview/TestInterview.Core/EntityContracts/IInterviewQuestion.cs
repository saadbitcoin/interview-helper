using MicroserviceHandlers.Contracts.TestInterview;
using SharedKernel.Serialization;

namespace TestInterview.Core.EntityContracts
{
    public interface IInterviewQuestion : IHasSerializableStateAsync<InterviewQuestionDTO>
    {

    }
}