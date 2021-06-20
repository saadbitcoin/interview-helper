using System.Threading.Tasks;
using SharedKernel.Selections;

namespace TestInterview.Core.EntityContracts
{
    public interface ITestInterviewTemplates : ISelectionAsync<ITestInterviewTemplate>
    {
        Task<int> Create(string title, (int tagId, int count)[] questionData);
    }
}