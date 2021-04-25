using KnowledgeBase.Application.UseCaseHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace KnowledgeBase.Application
{
    public static class StartupSettings
    {
        public static void AddUseCaseHandlers(this IServiceCollection services)
        {
            services.AddTransient<AddQuestionHandler>();
            services.AddTransient<AddTagHandler>();
            services.AddTransient<LinkNewTagToQuestionHandler>();
            services.AddTransient<ObtainQuestionsByLinkedTagsHandler>();
            services.AddTransient<ObtainQuestionByIdentifierHandler>();
            services.AddTransient<WithdrawTagsFromQuestionHandler>();
        }
    }
}
