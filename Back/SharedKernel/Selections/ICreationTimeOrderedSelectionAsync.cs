using System.Threading.Tasks;

namespace SharedKernel.Selections
{
    public interface ICreationTimeOrderedSelectionAsync<T>
    {
        Task<T[]> LastAdded(int count);
    }
}