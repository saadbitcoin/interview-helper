using System.Threading.Tasks;

namespace TestInterview.Core.EntityContracts
{
    public interface ITestInterviewTemplate
    {
        Task<ITestInterview> TestInterview(int userId);
    }
}


