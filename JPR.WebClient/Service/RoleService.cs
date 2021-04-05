using jpr.core;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace JPR.WebClient
{
    public class RoleService : IRoleService
    {

        public HttpClient Client { get; }

        public WebRequest Request => new WebRequest(Client);

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="httpClient"></param>
        public RoleService(HttpClient httpClient)
        {

            httpClient.BaseAddress = new Uri("https://localhost:5030/");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "jpr.server");

            Client = httpClient;
        }

        /// <summary>
        /// Tries to get all roles on the server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <returns>Returns the result of a successful request</returns>
        public async Task<RolesResultsApiModel> GetRolesAsync(string token)
        {
            WebRequest webRequest = new WebRequest(Client);

            var users = await webRequest.GetApiResponseAsync<ApiResponse<RolesResultsApiModel>>(
                 ApplicationMediaType.Json,
                 RoleApiRoutes.Roles,
                 null,
                 token
                 );

            var results = new RolesResultsApiModel();

            results.AddRange(users.Response);

            return results;
        }


        /// <summary>
        /// Tries to delete a role on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">the role details</param>
        /// <returns>Returns the result of a successful request</returns>
        public async Task<ApiResponse> DeleteRoleAsync(string token, RoleApiModel model)
        {
            WebRequest webRequest = new WebRequest(Client);

            var response = await webRequest.GetApiResponseAsync<ApiResponse>(
                 ApplicationMediaType.Json,
                 RoleApiRoutes.Delete,
                 model,
                 token
                 );
            if (!response.Successful)
                // Return failed Response
                return new ApiResponse() { ErrorMessage = "Failed to delete" };

            return new ApiResponse();
        }

        /// <summary>
        /// Tries to add a role on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">the role details</param>
        /// <returns>Returns the result of a successful request</returns>
        public async Task<ApiResponse> AddRoleAsync(string token, RoleApiModel model)
        {
            WebRequest webRequest = new WebRequest(Client);

            var response = await webRequest.GetApiResponseAsync<ApiResponse>(
                 ApplicationMediaType.Json,
                 RoleApiRoutes.Register,
                 model,
                 token
                 );
            if (!response.Successful)
                // Return failed Response
                return new ApiResponse() { ErrorMessage = "Failed to update" };

            return new ApiResponse();
        }


        /// <summary>
        /// Tries to add or remove a user from a role on the server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">the Role details</param>
        /// <returns>Returns the result of a successful request</returns>
        public async Task<ApiResponse> AddOrRemoveRoleAsync(string token, RoleApiModel model)
        {
            WebRequest webRequest = new WebRequest(Client);

            var response = await webRequest.GetApiResponseAsync<ApiResponse>(
                 ApplicationMediaType.Json,
                 RoleApiRoutes.AddAndRemove,
                 model,
                 token
                 );
            if (!response.Successful)
                // Return failed Response
                return new ApiResponse() { ErrorMessage = "Failed to Add the user" };

            return new ApiResponse();
        }

        public Task<ApiResponse> UpdateRoleAsync(string token, RoleApiModel model)
        {
            throw new NotImplementedException();
        }
    }
}
