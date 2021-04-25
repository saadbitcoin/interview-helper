using System.Threading.Tasks;
using KnowledgeBase.Domain;

namespace KnowledgeBase.Application.Repositories
{
    public interface IQuestionsRepository
    {
        Task<Question> GetQuestion(int id);
        Task<Question[]> GetQuestions(string tagTitle, string[] tagValues);
        Task<int> AddQuestion(Question target);
        Task RemoveQuestion(int id);
        Task<(int createdTagValues, int existedTagValues)> LinkTags(int questionId, string tagTitle, string[] tagValues);
        Task<int> WithdrawTags(int questionId, string tagTitle, string[] tagValues);
    }
}