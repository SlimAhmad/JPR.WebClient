using jpr.core;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace JPR.WebClient
{
    public class WebRequest
    {

        private HttpClient Client { get; }

        public WebRequest(HttpClient httpClient)
        {
            Client = httpClient;
        }
        public WebRequest()
        {

        }

        public async Task<TRespone> GetApiResponseAsync<TRespone>(ApplicationMediaType mediaType, string apiRoute, object content = null, string token = null)
        {

            if (!string.IsNullOrWhiteSpace(token))
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


            if (mediaType == ApplicationMediaType.MultipartFormData)
            {



                var httpResponse = await Client.PostAsync(RouteHelpers.GetAbsoluteRoute(PictureApiRoutes.UploadLogo, "https://localhost:5030"),
                    (HttpContent)content);
                var body = await httpResponse.Content.ReadAsStringAsync();

                var results = JsonConvert.DeserializeObject<TRespone>(body);
                return await Task.FromResult(results);
            }


            string serializedContent = JsonConvert.SerializeObject(content);

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, apiRoute);
            requestMessage.Content = new StringContent(serializedContent);
            requestMessage.Content.Headers.ContentType
                = new MediaTypeHeaderValue(mediaType.ToMediaTypes());

            var response = await Client.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<TRespone>(responseBody);

            return await Task.FromResult(result);

        }

    }
}
