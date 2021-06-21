namespace TestInterview.Core.Schemas
{
    #region Schemas
    public record QuestionsDataSchema(int tagId, int count);
    public record InterviewQuestionSchema(int id, string title);
    public record InterviewTemplateSchema(int id, string title);
    public record InterviewSchema(InterviewQuestionSchema[] questions);
    #endregion

    #region Requests
    public record InterviewTemplateCreationRequestModel(string title, QuestionsDataSchema[] questionData);
    #endregion

    #region Responses
    public record InterviewTemplateCreationResponseModel(int newInterviewTemplateId);
    #endregion
}