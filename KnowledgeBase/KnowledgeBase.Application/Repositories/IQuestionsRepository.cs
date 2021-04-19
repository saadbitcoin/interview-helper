using System.Threading.Tasks;
using KnowledgeBase.Domain;

namespace KnowledgeBase.Application.Repositories
{
    public interface IQuestionsRepository
    {
        Task<Question> GetQuestion(int id);
        Task<Question[]> GetQuestions(LinkedTag tag);
        Task<Question[]> GetQuestions(LinkedTag[] tags);
        Task<int> AddQuestion(Question target);
        Task RemoveQuestion(int id);
    }
}