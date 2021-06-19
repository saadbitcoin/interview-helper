using System.Threading.Tasks;

namespace MicroserviceHandlers.Contracts.QuestionsList
{
    #region Model schemas
    public record TagSchema(int id, string title);
    public record QuestionSchema(int id, string title, string answer);
    public record QuestionWithTagSchema(QuestionSchema question, TagSchema[] tags);
    #endregion

    #region Requests
    public record QuestionCreationRequestModel(string title, string answer, int[] tagIds);
    public record TagCreationRequestModel(string title);
    #endregion

    #region Responses
    public record QuestionCreationResponseModel(int newQuestionId);
    public record TagCreationResponseModel(int newTagId);
    #endregion

    public interface IQuestionsListMicroservice
    {
        Task<QuestionCreationResponseModel> CreateQuestion(QuestionCreationRequestModel request);
        Task<TagCreationResponseModel> CreateTag(TagCreationRequestModel request);
        Task<QuestionWithTagSchema[]> RecentlyAddedQuestions(int count);
        Task<QuestionWithTagSchema[]> QuestionsByTagsUnion(int[] tagIds);
        Task<QuestionWithTagSchema[]> RandomQuestionsByTag(int tagId, int count);
        Task<QuestionWithTagSchema> Question(int id);
        Task<TagSchema[]> Tags();
    }
}