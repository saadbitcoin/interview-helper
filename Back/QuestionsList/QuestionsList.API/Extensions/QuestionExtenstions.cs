using System.Linq;
using System.Threading.Tasks;
using MicroserviceHandlers.Contracts.QuestionsList;
using QuestionsList.Core.EntityContracts;

namespace QuestionsList.API.Extenstions
{
    public static class QuestionExtenstions
    {
        public static async Task<QuestionWithTagSchema> ToFullDTO(this IQuestion question)
        {
            var questionState = await question.SerializableState();
            var tags = await question.Tags();
            var tagStates = await Task.WhenAll(tags.Select(x => x.SerializableState()));

            return new QuestionWithTagSchema(questionState, tagStates);
        }
    }
}