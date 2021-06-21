using System.Threading.Tasks;
using MicroserviceHandlers.Contracts.QuestionsList;

namespace TestInterview.Core.EntityContracts
{
    public interface IUnansweredQuestions
    {
        Task<int> Add(int questionId);
        Task Remove(int questionId);
        Task<IUnansweredQuestion[]> Elements(IQuestionsListMicroservice questionsListMicroservice);
    }
}