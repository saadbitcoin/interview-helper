using System.Threading.Tasks;
using MicroserviceHandlers.Contracts.TestInterview;
using SharedKernel.Serialization;

namespace TestInterview.Core.EntityContracts
{
    public interface ITestInterviewTemplate : IHasSerializableStateAsync<TestInterviewTemplateSchema>
    {
        Task<IQuestionsData[]> QuestionsData();
    }
}