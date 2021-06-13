using System.Threading.Tasks;
using TestInterview.Core.EntityContracts;
using Newtonsoft.Json;

namespace TestInterview.Core.Entities
{
    public sealed class PrefilledQuestion : IQuestion
    {
        private readonly int _id;
        private readonly string _title;

        public PrefilledQuestion(int id, string title)
        {
            _id = id;
            _title = title;
        }

        public Task<string> JSON()
        {
            return Task.FromResult(JsonConvert.SerializeObject(new
            {
                id = _id,
                title = _title
            }));
        }
    }
}