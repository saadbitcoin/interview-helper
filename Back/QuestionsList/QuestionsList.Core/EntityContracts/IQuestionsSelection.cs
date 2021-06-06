using SharedKernel.Selections;

namespace QuestionsList.Core.EntityContracts
{
    public interface IQuestionsSelection : ISelectionAsync<IQuestion>, IRandomAccessSelectionAsync<IQuestion>
    {

    }
}