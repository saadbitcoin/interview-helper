using System.Linq;
using System.Threading.Tasks;
using KnowledgeBase.Domain.Entities.Base;
using Command = KnowledgeBase.Domain.Operations.Tags.Create;

namespace KnowledgeBase.Infrastructure.DataAccess.Operations
{
    public class CreateTagHandler : Command.IHandler
    {
        private readonly KnowledgeBaseContext _context;

        public CreateTagHandler(KnowledgeBaseContext context)
        {
            _context = context;
        }

        public async Task<Command.Response> Handle(Command.Request requestData)
        {
            var target = _context.Tags.FirstOrDefault(x => x.Title == requestData.Title);

            if (target != null)
            {
                return new Command.Response
                {
                    Success = false,
                    TagIdentifier = target.Id
                };
            }

            target = new Tag
            {
                Title = requestData.Title
            };

            _context.Tags.Add(target);
            await _context.SaveChangesAsync();

            return new Command.Response
            {
                Success = true,
                TagIdentifier = target.Id
            };
        }
    }
}