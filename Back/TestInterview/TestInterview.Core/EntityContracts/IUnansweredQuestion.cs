using System.Threading.Tasks;

namespace TestInterview.Core.EntityContracts
{
    public interface IUnansweredQuestion : IInterviewQuestion
    {
        Task<string> Answer();
    }
}