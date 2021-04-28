using System.Linq;
using System.Threading.Tasks;
using Query = KnowledgeBase.Domain.Operations.Tags.GetAll;

namespace KnowledgeBase.Infrastructure.DataAccess.Operations
{
    public class GetAllTagsHandler : Query.IHandler
    {
        private readonly KnowledgeBaseContext _context;

        public GetAllTagsHandler(KnowledgeBaseContext context)
        {
            _context = context;
        }

        public Task<Query.Response> Handle(Query.Request requestData)
        {
            return Task.FromResult(
                new Query.Response
                {
                    Tags = _context.Tags.ToArray()
                }
            );
        }
    }
}