using System.Threading.Tasks;

namespace SharedKernel.Serialization
{
    public interface IHasSerializableStateAsync<Schema>
    {
        Task<Schema> SerializableState();
    }
}