using System.Threading.Tasks;
using Newtonsoft.Json;
using TestInterview.Core.EntityContracts;

namespace TestInterview.Core.Entities
{
    public sealed class PrefilledFullQuestionInfo : IFullQuestionInfo
    {
        private readonly IQuestion _question;
        private readonly string _answer;

        public PrefilledFullQuestionInfo(IQuestion question, string answer)
        {
            _question = question;
            _answer = answer;
        }

        public async Task<string> JSON()
        {
            var questionJSON = await _question.JSON();

            return JsonConvert.SerializeObject(new
            {
                question = questionJSON,
                answer = _answer
            });
        }
    }
}