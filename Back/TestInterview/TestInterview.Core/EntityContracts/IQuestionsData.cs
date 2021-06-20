using System.Threading.Tasks;
using MicroserviceHandlers.Contracts.TestInterview;
using SharedKernel.Serialization;

namespace TestInterview.Core.EntityContracts
{
    public interface IQuestionsData
    {
        Task<int> TagId();
        Task<int> Count();
    }
}