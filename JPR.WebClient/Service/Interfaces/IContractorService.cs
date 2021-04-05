using jpr.core;
using System.IO;

using System.Threading.Tasks;

namespace JPR.WebClient
{
    public interface IContractorService
    {

        /// <summary>
        /// Tries to get all contractors on the server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <returns>Returns the result of a successful request</returns>
        Task<ContractorResultsApiModel> GetContractorsAsync(string token);

        /// <summary>
        /// Tries to add a contractor on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">the contractor details</param>
        /// <returns>Returns the result of a successful request</returns>
        Task<ApiResponse> AddContractorAsync(string token, ContractorApiModel model);


        /// <summary>
        /// Tries to update a contractor on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">the contractor details</param>
        /// <returns>Returns the result of a successful request</returns>
        Task<ApiResponse> UpdateContractorAsync(string token, ContractorApiModel model);

        /// <summary>
        /// Tries to upload a contractor logo on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">the contractor details</param>
        /// <returns>Returns the result of a successful request</returns>
        Task<ApiResponse<LogoApiModel>> UploadogoAsync(string token, Stream fileStream, ContractorApiModel contractor, string fileName);

        /// <summary>
        /// Tries to delete a contractor on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">the contractor details</param>
        /// <returns>Returns the result of a successful request</returns>
        Task<ApiResponse> DeleteContractorAsync(string token, ContractorApiModel model);




    }
}
