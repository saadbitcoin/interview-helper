using KnowledgeBase.Application.UseCaseHandlers;
using Microsoft.Extensions.DependencyInjection;
using UseCases = KnowledgeBase.Domain.UseCases;

namespace KnowledgeBase.Application
{
    public static class StartupSettings
    {
        public static void AddUseCaseHandlers(this IServiceCollection services)
        {
            services.AddTransient<UseCases.CreateLinkedQuestionFromScratch.IHandler, CreateLinkedQuestionFromScratchHandler>();
            services.AddTransient<UseCases.GetTaggedQuestionsByTagIds.IHandler, GetTaggedQuestionsByTagIdsHandler>();
            services.AddTransient<UseCases.LinkTagsToQuestion.IHandler, LinkTagsToQuestionHandler>();
            services.AddTransient<UseCases.WithdrawTagsFromQuestion.IHandler, WithdrawTagsFromQuestionHandler>();
            services.AddTransient<UseCases.GetTaggedQuestionByQuestionId.IHandler, GetTaggedQuestionByQuestionIdHandler>();
        }
    }
}
