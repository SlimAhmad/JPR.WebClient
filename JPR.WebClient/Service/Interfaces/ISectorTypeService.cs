using jpr.core;
using System.Threading.Tasks;

namespace JPR.WebClient
{
    public interface ISectorTypeService
    {

        /// <summary>
        /// Tries to get all Sector types on the server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <returns>Returns the result of a successful request</returns>
        Task<SectorTypeResultsApiModel> GetSectorTypesAsync(string token);

        /// <summary>
        /// Tries to add a sector type on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">the sector type details</param>
        /// <returns>Returns the result of a successful request</returns>
        Task<ApiResponse> AddSectorTypeAsync(string token, SectorTypeApiModel model);


        /// <summary>
        /// Tries to update a sector type on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">the sector type details</param>
        /// <returns>Returns the result of a successful request</returns>
        Task<ApiResponse> UpdateSectorTypeAsync(string token, SectorTypeApiModel model);

        /// <summary>
        /// Tries to delete a sector type on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">the sector type details</param>
        /// <returns>Returns the result of a successful request</returns>
        Task<ApiResponse> DeleteSectorTypeAsync(string token, SectorTypeApiModel model);




    }
}
