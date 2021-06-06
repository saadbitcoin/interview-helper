using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using QuestionsList.Core.EntityContracts;
using SharedKernel.JSON;

namespace QuestionsList.Core.Entities
{
    public sealed class PrefilledQuestion : IQuestion
    {
        private readonly int _id;
        private readonly string _title;
        private readonly string _answer;
        private readonly ITag[] _tags;

        public PrefilledQuestion(int id, string title, string answer, IEnumerable<ITag> tags) : this(id, title, answer, tags.ToArray())
        {

        }

        public PrefilledQuestion(int id, string title, string answer, ITag[] tags)
        {
            _id = id;
            _title = title;
            _answer = answer;
            _tags = tags;
        }

        public async Task<string> JSON()
        {
            var tagsAsJSONArray = new JSONArrayAsync(_tags);
            var tagsJSON = await tagsAsJSONArray.JSON();
            return JsonConvert.SerializeObject(
                new
                {
                    id = _id,
                    title = _title,
                    answer = _answer,
                    tags = JsonConvert.DeserializeObject(tagsJSON)
                }
            );
        }
    }
}