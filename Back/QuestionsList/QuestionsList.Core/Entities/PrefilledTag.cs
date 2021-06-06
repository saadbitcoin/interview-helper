using System.Threading.Tasks;
using Newtonsoft.Json;
using QuestionsList.Core.EntityContracts;

namespace QuestionsList.Core.Entities
{
    public sealed class PrefilledTag : ITag
    {
        private readonly int _id;
        private readonly string _title;

        public PrefilledTag(int id, string title)
        {
            _id = id;
            _title = title;
        }

        public Task<string> JSON()
        {
            return Task.FromResult(
                JsonConvert.SerializeObject(new
                {
                    id = _id,
                    title = _title
                })
            );
        }
    }
}