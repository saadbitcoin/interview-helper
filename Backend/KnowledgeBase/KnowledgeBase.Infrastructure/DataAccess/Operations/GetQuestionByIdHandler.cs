using System.Linq;
using System.Threading.Tasks;
using Query = KnowledgeBase.Domain.Operations.Questions.GetById;

namespace KnowledgeBase.Infrastructure.DataAccess.Operations
{
    public class GetQuestionByIdHandler : Query.IHandler
    {
        private readonly KnowledgeBaseContext _context;

        public GetQuestionByIdHandler(KnowledgeBaseContext context)
        {
            _context = context;
        }

        public Task<Query.Response> Handle(Query.Request requestData)
        {
            var question = _context.Questions.FirstOrDefault(x => x.Id == requestData.QuestionIdentifier);

            return Task.FromResult(new Query.Response
            {
                Question = question,
                IsFound = question != null
            });
        }
    }
}