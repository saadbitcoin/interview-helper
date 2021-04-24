using KnowledgeBase.Application.Repositories;
using KnowledgeBase.Infrastructure.DataAccess;
using KnowledgeBase.Infrastructure.DataAccess.InternalRepositories;
using KnowledgeBase.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KnowledgeBase.Infrastructure
{
    public static class StartupSettings
    {
        public static void AddDataAccessLayer(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<KnowledgeBaseContext>(options => options.UseNpgsql(connectionString));

            services.AddTransient<LinkedTagsRepository>();
            services.AddTransient<QuestionLinkedTagsRepository>();
            services.AddTransient<QuestionTableRepresentationsRepository>();
            services.AddTransient<TagTableRepresentationsRepository>();

            services.AddTransient<IQuestionsRepository, QuestionsRepository>();
            services.AddTransient<ITagsRepository, TagsRepository>();
        }
    }
}
