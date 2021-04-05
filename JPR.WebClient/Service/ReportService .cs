using jpr.core;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace JPR.WebClient
{
    public class ReportService : IReportService
    {

        public HttpClient Client { get; }

        public WebRequest Request => new WebRequest(Client);

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="httpClient"></param>
        public ReportService(HttpClient httpClient)
        {

            httpClient.BaseAddress = new Uri("https://localhost:5030/");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "jpr.server");

            Client = httpClient;
        }

        /// <summary>
        /// Tries to get all reports on the server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <returns>Returns the result of a successful request</returns>
        public async Task<ReportsResultsApiModel> GetReportsAsync(string token)
        {
            WebRequest webRequest = new WebRequest(Client);

            var users = await webRequest.GetApiResponseAsync<ApiResponse<ReportsResultsApiModel>>(
                 ApplicationMediaType.Json,
                 ReportApiRoutes.Reports,
                 null,
                 token
                 );

            var results = new ReportsResultsApiModel();

            results.AddRange(users.Response);

            return results;
        }

        /// <summary>
        /// Tries to delete a report on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">the report details</param>
        /// <returns>Returns the result of a successful request</returns>
        public async Task<ApiResponse> DeleteReportAsync(string token, ReportApiModel model)
        {
            WebRequest webRequest = new WebRequest(Client);

            var response = await webRequest.GetApiResponseAsync<ApiResponse>(
                 ApplicationMediaType.Json,
                 ReportApiRoutes.Delete,
                 model,
                 token
                 );
            if (!response.Successful)
                // Return failed Response
                return new ApiResponse() { ErrorMessage = "Failed to delete" };

            return new ApiResponse();
        }

        /// <summary>
        /// Tries to update a report on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">the reports details</param>
        /// <returns>Returns the result of a successful request</returns>
        public async Task<ApiResponse> UpdateReportAsync(string token, ReportApiModel model)
        {
            WebRequest webRequest = new WebRequest(Client);

            var response = await webRequest.GetApiResponseAsync<ApiResponse>(
                 ApplicationMediaType.Json,
                 ReportApiRoutes.Update,
                 model,
                 token
                 );
            if (!response.Successful)
                // Return failed Response
                return new ApiResponse() { ErrorMessage = "Failed to update report" };

            return new ApiResponse();
        }

        /// <summary>
        /// Tries to add a report on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">the report details</param>
        /// <returns>Returns the result of a successful request</returns>
        public async Task<ApiResponse> AddReportAsync(string token, ReportApiModel model)
        {
            WebRequest webRequest = new WebRequest(Client);

            var response = await webRequest.GetApiResponseAsync<ApiResponse>(
                 ApplicationMediaType.Json,
                 ReportApiRoutes.Register,
                 model,
                 token
                 );
            if (!response.Successful)
                // Return failed Response
                return new ApiResponse() { ErrorMessage = "Failed to Add the user" };

            return new ApiResponse();
        }

        /// <summary>
        /// Tries to get a report on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <returns>Returns the result of a successful request</returns>
        public async Task<ReportApiModel> GetReportAsync(string token)
        {
            WebRequest webRequest = new WebRequest(Client);

            var response = await webRequest.GetApiResponseAsync<ApiResponse<ReportApiModel>>(
                 ApplicationMediaType.Json,
                 ReportApiRoutes.Report,
                 null,
                 token
                 );
            var results = new ReportApiModel();

            results = response.Response;

            return results;
        }


    }
}
