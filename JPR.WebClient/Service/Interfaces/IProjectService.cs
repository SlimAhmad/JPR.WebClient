using jpr.core;
using System.Threading.Tasks;

namespace JPR.WebClient
{
    public interface IProjectService
    {

        /// <summary>
        /// Tries to get all projects on the server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <returns>Returns the result of a successful request</returns>
        Task<ProjectsResultsApiModel> GetProjectsAsync(string token);

        /// <summary>
        /// Tries to add a project on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">the Projects details</param>
        /// <returns>Returns the result of a successful request</returns>
        Task<ApiResponse> AddProjectAsync(string token, ProjectsApiModel model);


        /// <summary>
        /// Tries to update a project on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">the Projects details</param>
        /// <returns>Returns the result of a successful request</returns>
        Task<ApiResponse> UpdateProjectAsync(string token, ProjectsApiModel model);

        /// <summary>
        /// Tries to delete a project on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">the Projects details</param>
        /// <returns>Returns the result of a successful request</returns>
        Task<ApiResponse> DeleteProjectAsync(string token, ProjectsApiModel model);

        /// <summary>
        /// Tries to get a project on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <returns>Returns the result of a successful request</returns>
        Task<ProjectsApiModel> GetProject(string token);

        /// <summary>
        /// Tries to search for all projects by its sector on to server
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<ProjectsResultsApiModel> FindbySectorAsync(string token, ProjectsApiModel model);
    }
}
