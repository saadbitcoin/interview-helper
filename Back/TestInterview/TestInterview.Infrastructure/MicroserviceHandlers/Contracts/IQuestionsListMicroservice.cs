using System.Threading.Tasks;
using TestInterview.Core.EntityContracts;

namespace TestInterview.Infrastructure.MicroserviceHandlers.Contracts
{
    public interface IQuestionsListMicroservice
    {
        Task<IQuestion[]> GetRandomQuestions((int tagId, int count)[] requestData);
        Task<(int id, string answer)[]> GetQuestionAnswersByIds(int[] questionIds);
    }
}