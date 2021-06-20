using System.Threading.Tasks;

namespace TestInterview.Core.EntityContracts
{
    public interface ITestInterview
    {
        Task<IInterviewQuestion[]> Questions();
    }
}