using System.Threading.Tasks;
using KnowledgeBase.Domain.Entities.Base;
using Command = KnowledgeBase.Domain.Operations.Questions.Create;

namespace KnowledgeBase.Infrastructure.DataAccess.Operations
{
    public class CreateQuestionHandler : Command.IHandler
    {
        private readonly KnowledgeBaseContext _context;

        public CreateQuestionHandler(KnowledgeBaseContext context)
        {
            _context = context;
        }

        public async Task<Command.Response> Handle(Command.Request requestData)
        {
            var target = new Question
            {
                Answer = requestData.Answer,
                Title = requestData.Title
            };

            _context.Questions.Add(target);
            await _context.SaveChangesAsync();

            return new Command.Response { QuestionIdentifier = target.Id, Success = true };
        }
    }
}