using System.Threading.Tasks;
using SharedKernel.Selections;

namespace TestInterview.Core.EntityContracts
{
    public interface IInterviewTemplates : ISelectionAsync<IInterviewTemplate>
    {
        Task<int> Create(string title, (int tagId, int count)[] questionData);
    }
}