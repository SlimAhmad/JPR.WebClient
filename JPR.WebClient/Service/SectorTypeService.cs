using jpr.core;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace JPR.WebClient
{
    public class SectorTypeService : ISectorTypeService
    {

        public HttpClient Client { get; }

        public WebRequest Request => new WebRequest(Client);

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="httpClient"></param>
        public SectorTypeService(HttpClient httpClient)
        {

            httpClient.BaseAddress = new Uri("https://localhost:5030/");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "jpr.server");

            Client = httpClient;
        }

        /// <summary>
        /// Tries to get all Sector types on the server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <returns>Returns the result of a successful request</returns>
        public async Task<SectorTypeResultsApiModel> GetSectorTypesAsync(string token)
        {
            WebRequest webRequest = new WebRequest(Client);

            var users = await webRequest.GetApiResponseAsync<ApiResponse<SectorTypeResultsApiModel>>(
                 ApplicationMediaType.Json,
                 SectorTypeApiRoutes.SectorType,
                 null,
                 token
                 );

            var results = new SectorTypeResultsApiModel();

            results.AddRange(users.Response);

            return results;
        }

        /// <summary>
        /// Tries to delete a sector type on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">the sector type details</param>
        /// <returns>Returns the result of a successful request</returns>
        public async Task<ApiResponse> DeleteSectorTypeAsync(string token, SectorTypeApiModel model)
        {
            WebRequest webRequest = new WebRequest(Client);

            var response = await webRequest.GetApiResponseAsync<ApiResponse>(
                 ApplicationMediaType.Json,
                 SectorTypeApiRoutes.Delete,
                 model,
                 token
                 );
            if (!response.Successful)
                // Return failed Response
                return new ApiResponse() { ErrorMessage = "Failed to delete" };

            return new ApiResponse();
        }

        /// <summary>
        /// Tries to update a sector type on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">the sector type details</param>
        /// <returns>Returns the result of a successful request</returns>
        public async Task<ApiResponse> UpdateSectorTypeAsync(string token, SectorTypeApiModel model)
        {
            WebRequest webRequest = new WebRequest(Client);

            var response = await webRequest.GetApiResponseAsync<ApiResponse>(
                 ApplicationMediaType.Json,
                 SectorTypeApiRoutes.Update,
                 model,
                 token
                 );
            if (!response.Successful)
                // Return failed Response
                return new ApiResponse() { ErrorMessage = "Failed to update" };

            return new ApiResponse();
        }


        /// <summary>
        /// Tries to add a sector type on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">the sector type details</param>
        /// <returns>Returns the result of a successful request</returns>
        public async Task<ApiResponse> AddSectorTypeAsync(string token, SectorTypeApiModel model)
        {
            WebRequest webRequest = new WebRequest(Client);

            var response = await webRequest.GetApiResponseAsync<ApiResponse>(
                 ApplicationMediaType.Json,
                 SectorTypeApiRoutes.Register,
                 model,
                 token
                 );
            if (!response.Successful)
                // Return failed Response
                return new ApiResponse() { ErrorMessage = "Failed to Add the user" };

            return new ApiResponse();
        }




    }
}
