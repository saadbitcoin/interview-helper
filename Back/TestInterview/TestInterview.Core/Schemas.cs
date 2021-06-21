namespace TestInterview.Core.Schemas
{
    public record InterviewQuestionSchema(int id, string title);
    public record InterviewTemplateSchema(int id, string title);
    public record InterviewSchema(InterviewQuestionSchema[] questions);
}