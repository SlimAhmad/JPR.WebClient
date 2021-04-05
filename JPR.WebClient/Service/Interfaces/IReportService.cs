using jpr.core;
using System.Threading.Tasks;

namespace JPR.WebClient
{
    public interface IReportService
    {

        /// <summary>
        /// Tries to get all reports on the server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <returns>Returns the result of a successful request</returns>
        Task<ReportsResultsApiModel> GetReportsAsync(string token);

        /// <summary>
        /// Tries to add a report on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">the report details</param>
        /// <returns>Returns the result of a successful request</returns>
        Task<ApiResponse> AddReportAsync(string token, ReportApiModel model);


        /// <summary>
        /// Tries to update a report on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">the reports details</param>
        /// <returns>Returns the result of a successful request</returns>
        Task<ApiResponse> UpdateReportAsync(string token, ReportApiModel model);

        /// <summary>
        /// Tries to delete a report on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">the report details</param>
        /// <returns>Returns the result of a successful request</returns>
        Task<ApiResponse> DeleteReportAsync(string token, ReportApiModel model);

        /// <summary>
        /// Tries to get a report on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <returns>Returns the result of a successful request</returns>
        Task<ReportApiModel> GetReportAsync(string token);


    }
}
