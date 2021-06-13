using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestInterview.Core.Entities;
using TestInterview.Core.EntityContracts;
using TestInterview.Infrastructure.MicroserviceHandlers.Contracts;

namespace TestInterview.Infrastructure.MicroserviceHandlers
{
    public sealed class QuestionsListMicroservice : IQuestionsListMicroservice
    {
        private readonly string _microserviceURL;

        public QuestionsListMicroservice(string microserviceURL)
        {
            _microserviceURL = microserviceURL;
        }

        public async Task<(int id, string answer)[]> GetQuestionAnswersByIds(int[] questionIds)
        {
            var toReturn = new List<(int id, string answer)>();

            foreach (var id in questionIds)
            {
                var webRequest = WebRequest.Create(
                    $"{_microserviceURL}/questions/{id}"
                );
                var response = await webRequest.GetResponseAsync();
                using (Stream dataStream = response.GetResponseStream())
                {
                    var reader = new StreamReader(dataStream);
                    var responseFromServer = reader.ReadToEnd();
                    var questionData = JsonConvert.DeserializeObject<dynamic>(responseFromServer);

                    toReturn.Add((questionData.id, questionData.answer));
                }
                response.Close();
            }

            return toReturn.ToArray();
        }

        public async Task<IQuestion[]> GetRandomQuestions((int tagId, int count)[] requestData)
        {
            var toReturn = new List<PrefilledQuestion>();

            foreach (var request in requestData)
            {
                var webRequest = WebRequest.Create(
                    $"{_microserviceURL}/questions/randomQuestionsByTag?tagId={request.tagId}&count={request.count}"
                );
                var response = await webRequest.GetResponseAsync();
                using (Stream dataStream = response.GetResponseStream())
                {
                    var reader = new StreamReader(dataStream);
                    var responseFromServer = reader.ReadToEnd();
                    var questions = JsonConvert
                        .DeserializeObject<dynamic[]>(responseFromServer)
                        .Select(x => new PrefilledQuestion(x.id, x.title));

                    toReturn.AddRange(questions);
                }
                response.Close();
            }

            return toReturn.ToArray();
        }
    }
}