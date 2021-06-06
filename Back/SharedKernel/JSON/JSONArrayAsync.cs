using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharedKernel.JSON
{
    public sealed class JSONArrayAsync : IJSONSerializableAsync
    {
        private readonly IJSONSerializableAsync[] _items;

        public JSONArrayAsync(IEnumerable<IJSONSerializableAsync> items) : this(items.ToArray())
        {

        }

        public JSONArrayAsync(IJSONSerializableAsync[] items)
        {
            _items = items;
        }

        public async Task<string> JSON()
        {
            var itemsJSONRepresentation = await Task.WhenAll(_items.Select(x => x.JSON()));
            var deserializedItems = itemsJSONRepresentation.Select(x => JsonConvert.DeserializeObject(x));

            return JsonConvert.SerializeObject(deserializedItems);
        }
    }
}