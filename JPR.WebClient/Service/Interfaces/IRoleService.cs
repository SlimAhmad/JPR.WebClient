using jpr.core;
using System.Threading.Tasks;

namespace JPR.WebClient
{
    public interface IRoleService
    {

        /// <summary>
        /// Tries to get all roles on the server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <returns>Returns the result of a successful request</returns>
        Task<RolesResultsApiModel> GetRolesAsync(string token);

        /// <summary>
        /// Tries to add a role on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">the Role details</param>
        /// <returns>Returns the result of a successful request</returns>
        Task<ApiResponse> AddRoleAsync(string token, RoleApiModel model);

        /// <summary>
        /// Tries to add or remove a user from a role role on the server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">The roles details</param>
        /// <returns>Returns the result of a successful request</returns>
        Task<ApiResponse> AddOrRemoveRoleAsync(string token, RoleApiModel model);

        /// <summary>
        /// Tries to update a role on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">The roles details</param>
        /// <returns>Returns the result of a successful request</returns>
        Task<ApiResponse> UpdateRoleAsync(string token, RoleApiModel model);

        /// <summary>
        /// Tries to delete a role on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">the role details</param>
        /// <returns>Returns the result of a successful request</returns>
        Task<ApiResponse> DeleteRoleAsync(string token, RoleApiModel model);



    }
}
