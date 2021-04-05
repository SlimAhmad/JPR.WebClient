using jpr.core;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace JPR.WebClient
{
    public class ContractorService : IContractorService
    {

        public HttpClient Client { get; }

        public WebRequest Request => new WebRequest(Client);

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="httpClient"></param>
        public ContractorService(HttpClient httpClient)
        {

            httpClient.BaseAddress = new Uri("https://localhost:5030/");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "jpr.server");

            Client = httpClient;
        }

        /// <summary>
        /// Tries to get all contractors on the server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <returns>Returns the result of a successful request</returns>
        public async Task<ContractorResultsApiModel> GetContractorsAsync(string token)
        {
            WebRequest webRequest = new WebRequest(Client);

            var users = await webRequest.GetApiResponseAsync<ApiResponse<ContractorResultsApiModel>>(
                 ApplicationMediaType.Json,
                 ContractorApiRoutes.Contractors,
                 null,
                 token
                 );

            var results = new ContractorResultsApiModel();

            results.AddRange(users.Response);

            return results;
        }

        /// <summary>
        /// Tries to delete a contractor on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">the contractor details</param>
        /// <returns>Returns the result of a successful request</returns>
        public async Task<ApiResponse> DeleteContractorAsync(string token, ContractorApiModel model)
        {
            WebRequest webRequest = new WebRequest(Client);

            var response = await webRequest.GetApiResponseAsync<ApiResponse>(
                 ApplicationMediaType.Json,
                 ContractorApiRoutes.Delete,
                 model,
                 token
                 );
            if (!response.Successful)
                // Return failed Response
                return new ApiResponse() { ErrorMessage = "Failed to delete" };

            return new ApiResponse();
        }

        /// <summary>
        /// Tries to update a contractor on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">the contractor details</param>
        /// <returns>Returns the result of a successful request</returns>
        public async Task<ApiResponse> UpdateContractorAsync(string token, ContractorApiModel model)
        {
            WebRequest webRequest = new WebRequest(Client);

            var response = await webRequest.GetApiResponseAsync<ApiResponse>(
                 ApplicationMediaType.Json,
                 ContractorApiRoutes.Update,
                 model,
                 token
                 );
            if (!response.Successful)
                // Return failed Response
                return new ApiResponse() { ErrorMessage = "Failed to update" };

            return new ApiResponse();
        }

        /// <summary>
        /// Tries to add a contractor on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">the contractor details</param>
        /// <returns>Returns the result of a successful request</returns>
        public async Task<ApiResponse> AddContractorAsync(string token, ContractorApiModel model)
        {
            WebRequest webRequest = new WebRequest(Client);

            var response = await webRequest.GetApiResponseAsync<ApiResponse>(
                 ApplicationMediaType.Json,
                 ContractorApiRoutes.Register,
                 model,
                 token
                 );
            if (!response.Successful)
                // Return failed Response
                return new ApiResponse() { ErrorMessage = "Failed to Add the user" };

            return new ApiResponse();
        }

        public async Task<ApiResponse<LogoApiModel>> UploadogoAsync(string token, Stream fileStream, ContractorApiModel contractor, string fileName)
        {
            WebRequest webRequest = new WebRequest(Client);
            var content = new MultipartFormDataContent();
            content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data");
            content.Add(new StreamContent(fileStream, (int)fileStream.Length), "Logo", fileName);
            content.Add(new StringContent(Convert.ToString(contractor.Id)), "ContractorId");
            content.Add(new StringContent(contractor.ContractorName), "ContractorName");

            var response = await webRequest.GetApiResponseAsync<ApiResponse<LogoApiModel>>(
               ApplicationMediaType.MultipartFormData,
               PictureApiRoutes.UploadLogo,
               content,
               token
               );
            if (!response.Successful)
                // Return failed Response
                return new ApiResponse<LogoApiModel>() { ErrorMessage = "Failed to Add the user" };

            return new ApiResponse<LogoApiModel>()
            {
                Response = response.Response
            };
        }
    }
}
