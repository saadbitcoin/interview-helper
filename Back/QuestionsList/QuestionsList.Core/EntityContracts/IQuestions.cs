using System.Threading.Tasks;
using SharedKernel.Selections;

namespace QuestionsList.Core.EntityContracts
{
    public interface IQuestions : ICreationTimeOrderedSelectionAsync<IQuestion>
    {
        Task<int> Add(string title, string answer, int[] tagIds);
    }
}