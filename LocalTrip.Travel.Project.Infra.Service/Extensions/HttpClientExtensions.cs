using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LocalTrip.Travel.Project.Infra.Service.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<(HttpResponseMessage response, TObjectResult objectSuccessResult)> SendRequestAsync<
            TObjectRequest, TObjectResult>(
            this HttpClient client,
            string endpoint,
            HttpMethod method,
            TObjectRequest objectRequest,
            Action SetAuthorization = null,
            bool automaticParseResult = true)
        {
            try
            {
                var response = await client.SendAsync(new HttpRequestMessage
                {
                    Method = method,
                    Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(objectRequest), Encoding.UTF8,
                        "application/json"),
                    RequestUri = new Uri($"{client.BaseAddress}{endpoint}"),
                }, HttpCompletionOption.ResponseHeadersRead);

                if (!response.IsSuccessStatusCode)
                    return (response, default(TObjectResult));

                if (automaticParseResult)
                    return (response,
                        DeserializeJsonFromStream<TObjectResult>(await response.Content.ReadAsStreamAsync()));
                
                return (response, default(TObjectResult));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        private static T DeserializeJsonFromStream<T>(Stream stream)
        {
            if (stream == null || stream.CanRead == false)
                return default(T);

            using (var streamReader = new StreamReader(stream))
            using (var jsonTextReader = new JsonTextReader(streamReader))
            {
                return new JsonSerializer().Deserialize<T>(jsonTextReader);
            }
        }
    }
}