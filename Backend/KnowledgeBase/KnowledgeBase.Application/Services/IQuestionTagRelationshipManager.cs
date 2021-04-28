using System.Threading.Tasks;

namespace KnowledgeBase.Application.Services
{
    public interface IQuestionTagRelationshipManager
    {
        Task<int> LinkTagsToQuestion(int questionId, int[] tagIds);
        Task<int> WithdrawTagsFromQuestion(int questionId, int[] tagIds);
    }
}