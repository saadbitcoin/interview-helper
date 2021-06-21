using SharedKernel.Serialization;
using MicroserviceHandlers.Contracts.QuestionsList;
using System.Threading.Tasks;

namespace QuestionsList.Core.EntityContracts
{
    public interface IQuestion : IHasSerializableStateAsync<QuestionSchema>
    {
        Task<ITag[]> Tags();
    }
}