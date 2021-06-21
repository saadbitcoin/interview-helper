using System.Threading.Tasks;
using MicroserviceHandlers.Contracts.QuestionsList;
using SharedKernel.Web;

namespace MicroserviceHandlers.WebAPI
{
    public sealed class QuestionsListWebAPIHandler : IQuestionsListMicroservice
    {
        private readonly WebAPIClient _questionsClient;
        private readonly WebAPIClient _tagsClient;

        public QuestionsListWebAPIHandler(string endpoint)
        {
            _questionsClient = new WebAPIClient(endpoint, "questions");
            _tagsClient = new WebAPIClient(endpoint, "tags");
        }

        public Task<QuestionCreationResponseModel> CreateQuestion(QuestionCreationRequestModel request)
            => _questionsClient.POST<QuestionCreationRequestModel, QuestionCreationResponseModel>(string.Empty, request);

        public Task<TagCreationResponseModel> CreateTag(TagCreationRequestModel request)
            => _tagsClient.POST<TagCreationRequestModel, TagCreationResponseModel>(string.Empty, request);

        public Task<QuestionWithTagSchema> Question(int id)
            => _questionsClient.GET<QuestionWithTagSchema>($"{id}");

        public Task<QuestionWithTagSchema[]> QuestionsByTagsUnion(int[] tagIds)
            => _questionsClient.GET<QuestionWithTagSchema[]>($"unionTagged/{string.Join(',', tagIds)}");

        public Task<QuestionWithTagSchema[]> RandomQuestionsByTag(int tagId, int count)
            => _questionsClient.GET<QuestionWithTagSchema[]>($"randomQuestionsByTag?tagid={tagId}&count={count}");

        public Task<QuestionWithTagSchema[]> RecentlyAddedQuestions(int count)
            => _questionsClient.GET<QuestionWithTagSchema[]>($"recentlyAdded?count={count}");

        public Task<TagSchema[]> Tags()
            => _tagsClient.GET<TagSchema[]>(string.Empty);
    }
}