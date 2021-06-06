using System.Threading.Tasks;
using SharedKernel.Selections;

namespace QuestionsList.Core.EntityContracts
{
    public interface ITags : ISelectionAsync<ITag>
    {
        Task<int> Add(string title);
    }
}