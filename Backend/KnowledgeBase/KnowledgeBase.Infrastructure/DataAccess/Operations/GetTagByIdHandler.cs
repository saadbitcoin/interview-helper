using System.Linq;
using System.Threading.Tasks;
using Query = KnowledgeBase.Domain.Operations.Tags.GetById;

namespace KnowledgeBase.Infrastructure.DataAccess.Operations
{
    public class GetTagByIdHandler : Query.IHandler
    {
        private readonly KnowledgeBaseContext _context;

        public GetTagByIdHandler(KnowledgeBaseContext context)
        {
            _context = context;
        }

        public Task<Query.Response> Handle(Query.Request requestData)
        {
            var tag = _context.Tags.FirstOrDefault(x => x.Id == requestData.TagIdentifier);

            return Task.FromResult(new Query.Response
            {
                Tag = tag,
                IsFound = tag != null
            });
        }
    }
}