using jpr.core;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace JPR.WebClient
{
    public class ProjectService : IProjectService
    {

        public HttpClient Client { get; }

        public ProjectService(HttpClient httpClient)
        {

            httpClient.BaseAddress = new Uri("https://localhost:5030/");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "jpr.server");

            Client = httpClient;
        }



        /// <summary>
        /// Tries to get all projects on the server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <returns>Returns the result of a successful request</returns>
        public async Task<ProjectsResultsApiModel> GetProjectsAsync(string token)
        {
            WebRequest webRequest = new WebRequest(Client);

            var users = await webRequest.GetApiResponseAsync<ApiResponse<ProjectsResultsApiModel>>(
                 ApplicationMediaType.Json,
                 ProjectApiRoutes.Projects,
                 null,
                 token
                 );

            var results = new ProjectsResultsApiModel();

            results.AddRange(users.Response);
            return results;
        }

        /// <summary>
        /// Tries to delete a project on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">the Projects details</param>
        /// <returns>Returns the result of a successful request</returns>
        public async Task<ApiResponse> DeleteProjectAsync(string token, ProjectsApiModel model)
        {
            WebRequest webRequest = new WebRequest(Client);

            var response = await webRequest.GetApiResponseAsync<ApiResponse>(
                 ApplicationMediaType.Json,
                 ProjectApiRoutes.Delete,
                 model,
                 token
                 );
            if (!response.Successful)
                // Return failed Response
                return new ApiResponse() { ErrorMessage = "Failed to delete" };

            return new ApiResponse();
        }

        /// <summary>
        /// Tries to update a project on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">the Projects details</param>
        /// <returns>Returns the result of a successful request</returns>
        public async Task<ApiResponse> UpdateProjectAsync(string token, ProjectsApiModel model)
        {
            WebRequest webRequest = new WebRequest(Client);

            var response = await webRequest.GetApiResponseAsync<ApiResponse>(
                 ApplicationMediaType.Json,
                 ProjectApiRoutes.Update,
                 model,
                 token
                 );
            if (!response.Successful)
                // Return failed Response
                return new ApiResponse() { ErrorMessage = "Failed to update users information" };

            return new ApiResponse();
        }

        /// <summary>
        /// Tries to add a project on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">the Projects details</param>
        /// <returns>Returns the result of a successful request</returns>
        public async Task<ApiResponse> AddProjectAsync(string token, ProjectsApiModel model)
        {
            WebRequest webRequest = new WebRequest(Client);

            var response = await webRequest.GetApiResponseAsync<ApiResponse>(
                 ApplicationMediaType.Json,
                 ProjectApiRoutes.Register,
                 model,
                 token
                 );
            if (!response.Successful)
                // Return failed Response
                return new ApiResponse() { ErrorMessage = "Failed to Add the user" };

            return new ApiResponse();
        }

        /// <summary>
        /// Tries to search for all projects by its sector on to server
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<ProjectsResultsApiModel> FindbySectorAsync(string token, ProjectsApiModel model)
        {
            WebRequest webRequest = new WebRequest(Client);

            var response = await webRequest.GetApiResponseAsync<ApiResponse<ProjectsResultsApiModel>>(
                 ApplicationMediaType.Json,
                 ProjectApiRoutes.FindProjects,
                 model,
                 token
                 );
            var results = new ProjectsResultsApiModel();

            results.AddRange(response.Response);

            return results;
        }

        /// <summary>
        /// Tries to get a project on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <returns>Returns the result of a successful request</returns>
        public async Task<ProjectsApiModel> GetProject(string token)
        {
            WebRequest webRequest = new WebRequest(Client);

            var response = await webRequest.GetApiResponseAsync<ApiResponse<ProjectsApiModel>>(
                 ApplicationMediaType.Json,
                 ProjectApiRoutes.Project,
                 null,
                 token
                 );

            var results = new ProjectsApiModel();

            results = response.Response;

            return results;
        }


    }
}
