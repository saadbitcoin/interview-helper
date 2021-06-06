using System.Threading.Tasks;

namespace SharedKernel.Selections
{
    public interface ISelectionAsync<T>
    {
        Task<T[]> Elements();
    }
}