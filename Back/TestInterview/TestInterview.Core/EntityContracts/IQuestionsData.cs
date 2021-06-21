using System.Threading.Tasks;

namespace TestInterview.Core.EntityContracts
{
    public interface IQuestionsData
    {
        Task<int> TagId();
        Task<int> Count();
    }
}