using SharedKernel.Serialization;
using TestInterview.Core.Schemas;

namespace TestInterview.Core.EntityContracts
{
    public interface IInterviewQuestion : IHasSerializableStateAsync<InterviewQuestionSchema>
    {

    }
}