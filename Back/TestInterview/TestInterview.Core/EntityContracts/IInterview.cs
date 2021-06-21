using System.Threading.Tasks;

namespace TestInterview.Core.EntityContracts
{
    public interface IInterview
    {
        Task<IInterviewQuestion[]> Questions();
    }
}