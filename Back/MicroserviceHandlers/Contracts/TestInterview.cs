namespace MicroserviceHandlers.Contracts.TestInterview
{
    #region Model schemas
    public record InterviewQuestionSchema(int id, string title);
    public record TestInterviewTemplateSchema(int id, string title);
    #endregion
}