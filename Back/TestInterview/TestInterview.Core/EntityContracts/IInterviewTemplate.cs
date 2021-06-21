using System.Threading.Tasks;
using SharedKernel.Serialization;
using TestInterview.Core.Schemas;

namespace TestInterview.Core.EntityContracts
{
    public interface IInterviewTemplate : IHasSerializableStateAsync<InterviewTemplateSchema>
    {
        Task<IQuestionsData[]> QuestionsData();
    }
}