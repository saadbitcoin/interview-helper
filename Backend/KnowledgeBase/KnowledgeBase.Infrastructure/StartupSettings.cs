using KnowledgeBase.Infrastructure.DataAccess;
using KnowledgeBase.Infrastructure.DataAccess.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using KnowledgeBase.Application.Services;
using KnowledgeBase.Infrastructure.DataAccess.Services;
using Operations = KnowledgeBase.Domain.Operations;

namespace KnowledgeBase.Infrastructure
{
    public static class StartupSettings
    {
        public static void InjectPostgreSQLDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<KnowledgeBaseContext>(options => options.UseNpgsql(connectionString));
        }

        public static void InjectBaseEntitiesOperations(this IServiceCollection services)
        {
            services.AddTransient<Operations.Questions.Create.IHandler, CreateQuestionHandler>();
            services.AddTransient<Operations.Questions.GetById.IHandler, GetQuestionByIdHandler>();
            services.AddTransient<Operations.Tags.Create.IHandler, CreateTagHandler>();
            services.AddTransient<Operations.Tags.GetById.IHandler, GetTagByIdHandler>();
            services.AddTransient<Operations.Tags.GetAll.IHandler, GetAllTagsHandler>();
        }

        public static void InjectApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IQuestionTagRelationshipManager, QuestionTagRelationshipManager>();
            services.AddTransient<ITaggedQuestionFinder, TaggedQuestionFinder>();
        }
    }
}
