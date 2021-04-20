using System.Threading.Tasks;
using KnowledgeBase.Domain;

namespace KnowledgeBase.Application.Repositories
{
    public interface ITagsRepository
    {
        Task<int> AddTag(Tag target);
        Task<Tag> GetTag(string title);
    }
}