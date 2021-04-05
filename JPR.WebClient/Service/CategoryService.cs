using jpr.core;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace JPR.WebClient
{
    public class CategoryService : ICategoryService
    {

        public HttpClient Client { get; }

        public WebRequest Request => new WebRequest(Client);

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="httpClient"></param>
        public CategoryService(HttpClient httpClient)
        {

            httpClient.BaseAddress = new Uri("https://localhost:5030/");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "jpr.server");

            Client = httpClient;
        }

        /// <summary>
        /// Tries to get all categories on the server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <returns>Returns the result of a successful request</returns>
        public async Task<CategoryResultsApiModel> GetCategoriesAsync(string token)
        {
            WebRequest webRequest = new WebRequest(Client);

            var users = await webRequest.GetApiResponseAsync<ApiResponse<CategoryResultsApiModel>>(
                 ApplicationMediaType.Json,
                 CategoryApiRoutes.Categories,
                 null,
                 token
                 );

            var results = new CategoryResultsApiModel();

            results.AddRange(users.Response);

            return results;
        }


        /// <summary>
        /// Tries to delete a category on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">the category details</param>
        /// <returns>Returns the result of a successful request</returns>
        public async Task<ApiResponse> DeleteCategoryAsync(string token, CategoryApiModel model)
        {
            WebRequest webRequest = new WebRequest(Client);

            var response = await webRequest.GetApiResponseAsync<ApiResponse>(
                 ApplicationMediaType.Json,
                 CategoryApiRoutes.Delete,
                 model,
                 token
                 );
            if (!response.Successful)
                // Return failed Response
                return new ApiResponse() { ErrorMessage = "Failed to delete" };

            return new ApiResponse();
        }
        /// <summary>
        /// Tries to update a category on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">the category details</param>
        /// <returns>Returns the result of a successful request</returns>
        public async Task<ApiResponse> UpdateCategoryAsync(string token, CategoryApiModel model)
        {
            WebRequest webRequest = new WebRequest(Client);

            var response = await webRequest.GetApiResponseAsync<ApiResponse>(
                 ApplicationMediaType.Json,
                 CategoryApiRoutes.Update,
                 model,
                 token
                 );
            if (!response.Successful)
                // Return failed Response
                return new ApiResponse() { ErrorMessage = "Failed to update" };

            return new ApiResponse();
        }


        /// <summary>
        /// Tries to add a category on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">The category details</param>
        /// <returns>Returns the result of a successful request</returns>
        public async Task<ApiResponse> AddCategoryAsync(string token, CategoryApiModel model)
        {
            WebRequest webRequest = new WebRequest(Client);

            var response = await webRequest.GetApiResponseAsync<ApiResponse>(
                 ApplicationMediaType.Json,
                 CategoryApiRoutes.Register,
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
