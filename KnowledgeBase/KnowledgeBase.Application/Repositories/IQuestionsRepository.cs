using System.Collections.Generic;
using System.Threading.Tasks;
using KnowledgeBase.Domain;

namespace KnowledgeBase.Application.Repositories
{
    public interface IQuestionsRepository
    {
        Task<Question> GetQuestion(int id);
        Task<Question[]> GetQuestions(string tag, string[] tagValues);
        Task<Question[]> GetQuestions(Dictionary<string, string[]> tagsInformation);
        Task<int> AddQuestion(Question target);
        Task RemoveQuestion(int id);
    }
}