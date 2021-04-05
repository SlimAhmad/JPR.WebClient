using jpr.core;
using System.Threading.Tasks;

namespace JPR.WebClient
{
    public interface ISectorService
    {

        /// <summary>
        /// Tries to get all sectors on the server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <returns>Returns the result of a successful request</returns>
        Task<SectorsResultsApiModel> GetSectorsAsync(string token);

        /// <summary>
        /// Tries to add a sector on the server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">The category details</param>
        /// <returns>Returns the result of a successful request</returns>
        Task<ApiResponse> AddSectorAsync(string token, SectorsApiModel model);


        /// <summary>
        /// Tries to update a sector on the server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">the sector details</param>
        /// <returns>Returns the result of a successful request</returns>
        Task<ApiResponse> UpdateSectorAsync(string token, SectorsApiModel model);

        /// <summary>
        /// Tries to delete a sector on the server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">The sector details</param>
        /// <returns>Returns the result of a successful request</returns>
        Task<ApiResponse> DeleteSectorAsync(string token, SectorsApiModel model);




    }
}
