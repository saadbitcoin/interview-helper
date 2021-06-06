using System;
using System.Linq;

namespace SharedKernel.HTTPRouteObjects
{
    public sealed class HTTPRouteArray<T>
    {
        private readonly string _rawData;
        private readonly Func<string, T> _converter;

        public HTTPRouteArray(string userRequestData, Func<string, T> converter)
        {
            _rawData = userRequestData;
            _converter = converter;
        }

        public T[] Result => _rawData.Split(',').Select(_converter).ToArray();
    }
}