using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharedKernel.Web
{
    public sealed class WebAPIClient
    {
        private readonly string _endpoint;
        private readonly string _controller;

        public WebAPIClient(string endpoint, string controller)
        {
            _endpoint = endpoint;
            _controller = controller;
        }

        public async Task<string> GET(string methodRouteData)
        {
            var toReturn = string.Empty;
            var webRequest = WebRequest.Create($"{_endpoint}/{_controller}/{methodRouteData}");
            var response = await webRequest.GetResponseAsync();
            using (Stream dataStream = response.GetResponseStream())
            {
                var reader = new StreamReader(dataStream);
                var responseFromServer = await reader.ReadToEndAsync();
                toReturn = responseFromServer;
            }
            response.Close();
            return toReturn;
        }

        public async Task<Response> GET<Response>(string methodRouteData)
        {
            var content = await GET(methodRouteData);
            return JsonConvert.DeserializeObject<Response>(content);
        }

        public async Task<string> POST<Request>(string method, Request requestBody)
        {
            var toReturn = string.Empty;
            var webRequest = WebRequest.Create($"{_endpoint}/{_controller}/{method}");
            webRequest.ContentType = "application/json";
            webRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(await webRequest.GetRequestStreamAsync()))
            {
                string json = JsonConvert.SerializeObject(requestBody);
                streamWriter.Write(json);
            }

            var response = await webRequest.GetResponseAsync();
            using (Stream dataStream = response.GetResponseStream())
            {
                var reader = new StreamReader(dataStream);
                var responseFromServer = await reader.ReadToEndAsync();
                toReturn = responseFromServer;
            }
            response.Close();
            return toReturn;
        }

        public async Task<Response> POST<Request, Response>(string method, Request requestBody)
        {
            var content = await POST<Request>(method, requestBody);
            return JsonConvert.DeserializeObject<Response>(content);
        }
    }
}