using System.Threading.Tasks;
using KnowledgeBase.Domain;

namespace KnowledgeBase.Application.Repositories
{
    public interface ILinkedTagsRepository
    {
        Task<int> AddLinkedTag(LinkedTag target);
        Task<LinkedTag[]> GetLinkedTagsByTagTitle(string tagTitle);
        Task<LinkedTag[]> GetLinkedTagsByValue(string value);
        Task<LinkedTag> GetLinkedTag(string tagTitle, string value);
    }
}