using System.Threading.Tasks;
using KnowledgeBase.Domain.Entities;

namespace KnowledgeBase.Application.Services
{
    public interface ITaggedQuestionFinder
    {
        Task<TaggedQuestion[]> FindByTagsIntersection(int[] tagIds);
        Task<TaggedQuestion[]> FindByTagsUnion(int[] tagIds);
        Task<TaggedQuestion> GetByQuestionId(int questionId);
    }
}