using jpr.core;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace JPR.WebClient
{
    public class SectorService : ISectorService
    {

        public HttpClient Client { get; }

        public WebRequest Request => new WebRequest(Client);

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="httpClient"></param>
        public SectorService(HttpClient httpClient)
        {

            httpClient.BaseAddress = new Uri("https://localhost:5030/");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "jpr.server");

            Client = httpClient;
        }

        /// <summary>
        /// Tries to get all sectors on the server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <returns>Returns the result of a successful request</returns>
        public async Task<SectorsResultsApiModel> GetSectorsAsync(string token)
        {
            WebRequest webRequest = new WebRequest(Client);

            var users = await webRequest.GetApiResponseAsync<ApiResponse<SectorsResultsApiModel>>(
                 ApplicationMediaType.Json,
                 SectorApiRoutes.Sectors,
                 null,
                 token
                 );

            var results = new SectorsResultsApiModel();

            results.AddRange(users.Response);

            return results;
        }


        /// <summary>
        /// Tries to delete a sector on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">the sector details</param>
        /// <returns>Returns the result of a successful request</returns>
        public async Task<ApiResponse> DeleteSectorAsync(string token, SectorsApiModel model)
        {
            WebRequest webRequest = new WebRequest(Client);

            var response = await webRequest.GetApiResponseAsync<ApiResponse>(
                 ApplicationMediaType.Json,
                 SectorApiRoutes.Delete,
                 model,
                 token
                 );
            if (!response.Successful)
                // Return failed Response
                return new ApiResponse() { ErrorMessage = "Failed to delete" };

            return new ApiResponse();
        }
        /// <summary>
        /// Tries to update a sector on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">the sector details</param>
        /// <returns>Returns the result of a successful request</returns>
        public async Task<ApiResponse> UpdateSectorAsync(string token, SectorsApiModel model)
        {
            WebRequest webRequest = new WebRequest(Client);

            var response = await webRequest.GetApiResponseAsync<ApiResponse>(
                 ApplicationMediaType.Json,
                 SectorApiRoutes.Update,
                 model,
                 token
                 );
            if (!response.Successful)
                // Return failed Response
                return new ApiResponse() { ErrorMessage = "Failed to update" };

            return new ApiResponse();
        }


        /// <summary>
        /// Tries to add a sector on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">The sector details</param>
        /// <returns>Returns the result of a successful request</returns>
        public async Task<ApiResponse> AddSectorAsync(string token, SectorsApiModel model)
        {
            WebRequest webRequest = new WebRequest(Client);

            var response = await webRequest.GetApiResponseAsync<ApiResponse>(
                 ApplicationMediaType.Json,
                 SectorApiRoutes.Register,
                 model,
                 token
                 );
            if (!response.Successful)
                // Return failed Response
                return new ApiResponse() { ErrorMessage = "Failed to add project category" };

            return new ApiResponse();
        }

    }
}
