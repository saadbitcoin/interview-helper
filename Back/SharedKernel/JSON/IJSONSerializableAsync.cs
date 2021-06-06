using System.Threading.Tasks;

namespace SharedKernel.JSON
{
    public interface IJSONSerializableAsync
    {
        Task<string> JSON();
    }
}