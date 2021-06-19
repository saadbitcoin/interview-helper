using SharedKernel.Serialization;
using MicroserviceHandlers.Contracts.QuestionsList;

namespace QuestionsList.Core.EntityContracts
{
    public interface ITag : IHasSerializableStateAsync<TagSchema>
    {

    }
}