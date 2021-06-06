using System.Threading.Tasks;

namespace SharedKernel.Selections
{
    public interface IRandomAccessSelectionAsync<T>
    {
        Task<T[]> RandomElements(int count);
    }
}