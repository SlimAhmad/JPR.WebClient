using jpr.core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace jpr.Relational
{

    /// <summary>
    /// Stores and retrieves information about the client application 
    /// such as login credentials, messages, settings and so on
    /// in an SQLite database
    /// </summary>
    public class BaseClientDataStore : IClientDataStore
    {
        #region Protected Members

        /// <summary>
        /// The database context for the client data store
        /// </summary>
        protected ClientDataStoreDbContext mDbContext;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="dbContext">The database to use</param>
        public BaseClientDataStore(ClientDataStoreDbContext dbContext)
        {
            // Set local member
            mDbContext = dbContext;
        }
        #endregion


        #region Interface Implementation


        /// <summary>
        /// Determines if the current user has logged in credentials
        /// </summary>
        public async Task<bool> HasCredentialsAsync()
        {
            return await GetLoginCredentialsAsync() != null;
        }

        /// <summary>
        /// Makes sure the client data store is correctly set up
        /// </summary>
        /// <returns>Returns a task that will finish once setup is complete</returns>
        public async Task EnsureDataStoreAsync()
        {
            // Make sure the database exists and is created
            await mDbContext.Database.EnsureCreatedAsync();
        }

        #region User



        /// <summary>
        /// Gets the stored login credentials for this client
        /// </summary>
        /// <returns>Returns the login credentials if they exist, or null if none exist</returns>
        public Task<LoginCredentialsDataModel> GetLoginCredentialsAsync()
        {
            // Get the first column in the login credentials table, or null if none exist
            return Task.FromResult(mDbContext.LoginCredentials.FirstOrDefault());
        }

        /// <summary>
        /// Stores the given login credentials to the backing data store
        /// </summary>
        /// <param name="loginCredentials">The login credentials to save</param>
        /// <returns>Returns a task that will finish once the save is complete</returns>
        public async Task SaveLoginCredentialsAsync(LoginCredentialsDataModel loginCredentials)
        {
            // Clear all entries
            mDbContext.LoginCredentials.RemoveRange(mDbContext.LoginCredentials);


            // Add new one
            mDbContext.LoginCredentials.Add(loginCredentials);

            // Save changes
            await mDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Removes all login credentials stored in the data store
        /// </summary>
        /// <returns></returns>
        public async Task ClearAllLoginCredentialsAsync()
        {
            // Clear all entries
            mDbContext.LoginCredentials.RemoveRange(mDbContext.LoginCredentials);

            // Save changes
            await mDbContext.SaveChangesAsync();
        }


        #endregion

        #region Projects

        public Task<ProjectsResultsApiModel> GetProjectsAsync()
        {
            // Get the list of projects
            var result = mDbContext.Projects.Take(100).ToList();

            // Create a new list of results
            var results = new ProjectsResultsApiModel();

            // Add each centers details
            results.AddRange(result.Select(x => new ProjectsApiModel
            {

                User = x.User,
                Id = x.Id,
                Budget = x.Budget,
                DateUpdated = x.DateUpdated,
                Commissioned = x.Commissioned,
                Completion = x.Completion,
                TimeStamp = x.TimeStamp,
                Latitude = x.Latitude,
                Longitude = x.Longitude,
                Location = x.Location,
                Status = x.Status,
                Timespan = x.Timespan,
                Title = x.Title,
                SectorName = x.SectorName,
                SectorId = x.SectorId,
                LogoName = x.LogoName,
                ContractorName = x.ContractorName
            }));


            return Task.FromResult(results);
        }

        public Task<ProjectsResultsApiModel> GetProjectsBySectorNameAsync(string sectorName)
        {
            // Get the list of projects
            var result = mDbContext.Projects.Where(x => x.SectorName == sectorName).ToList();

            // Create a new list of results
            var results = new ProjectsResultsApiModel();

            // Add each centers details
            results.AddRange(result.Select(x => new ProjectsApiModel
            {

                User = x.User,
                Id = x.Id,
                Budget = x.Budget,
                DateUpdated = x.DateUpdated,
                Commissioned = x.Commissioned,
                Completion = x.Completion,
                TimeStamp = x.TimeStamp,
                Latitude = x.Latitude,
                Longitude = x.Longitude,
                Location = x.Location,
                Status = x.Status,
                Timespan = x.Timespan,
                Title = x.Title,
                SectorName = x.SectorName,
                SectorId = x.SectorId,
                LogoName = x.LogoName,
                ContractorName = x.ContractorName
            }));


            return Task.FromResult(results);
        }

        public async Task<ProjectsApiModel> GetProjectByTitleNameAsync(string title)
        {
            // Get the list of projects
            var result = await mDbContext.Projects.Where(x => x.Title == title).FirstOrDefaultAsync();

            // Create a new project
            var project = new ProjectsApiModel
            {
                User = result.User,
                Id = result.Id,
                Budget = result.Budget,
                DateUpdated = result.DateUpdated,
                Commissioned = result.Commissioned,
                Completion = result.Completion,
                TimeStamp = result.TimeStamp,
                Latitude = result.Latitude,
                Longitude = result.Longitude,
                Location = result.Location,
                Status = result.Status,
                Timespan = result.Timespan,
                Title = result.Title,
                SectorName = result.SectorName,
                SectorId = result.SectorId,
                LogoName = result.LogoName,
                ContractorName = result.ContractorName

            };




            return project;
        }


        public async Task SaveProjectsAsync(ProjectsResultsApiModel projects)
        {
            // Clear all entries
            mDbContext.Projects.RemoveRange(mDbContext.Projects);

            // Create a new list of results
            var results = new ProjectsResultsApiModel();

            // Add each centers details
            results.AddRange(projects.Select(x => new ProjectsApiModel
            {

                User = x.User,
                Id = x.Id,
                Budget = x.Budget,
                DateUpdated = x.DateUpdated,
                Commissioned = x.Commissioned,
                Completion = x.Completion,
                TimeStamp = x.TimeStamp,
                Latitude = x.Latitude,
                Longitude = x.Longitude,
                Location = x.Location,
                Status = x.Status,
                Timespan = x.Timespan,
                Title = x.Title,
                SectorName = x.SectorName,
                CategoryName = x.CategoryName,
                SectorId = x.SectorId,
                ContractorName = x.ContractorName,
                LogoName = x.LogoName


            }));

            // Add new one
            mDbContext.Projects.AddRange(results);

            // Save changes
            await mDbContext.SaveChangesAsync();
        }

        public async Task ClearAllProjectsAsync()
        {
            // Clear all entries
            mDbContext.Projects.RemoveRange(mDbContext.Projects);

            // Save changes
            await mDbContext.SaveChangesAsync();
        }

        #endregion

        #region Sectors

        public async Task<SectorsResultsApiModel> GetSectorsByNameAsync(string sectorName)
        {

            // Get the list of projects
            var result = mDbContext.Sectors.Where(x => x.SectorName == sectorName).ToList();

            // Create a new list of results
            var results = new SectorsResultsApiModel();

            // Add each centers details
            results.AddRange(result.Select(x => new SectorsApiModel
            {

                User = x.User,
                Id = x.Id,
                CategoryId = x.CategoryId,
                SectorId = x.SectorId,
                DateReported = x.DateReported,
                SectorTitle = x.SectorTitle,
                TimeStamp = x.TimeStamp,
                SectorName = x.SectorName,
                CategoryName = x.CategoryName
            }));


            return results;
        }


        public Task<SectorsResultsApiModel> GetSectorsAsync()
        {

            // Get the list of projects
            var result = mDbContext.Sectors.Take(100).ToList();

            // Create a new list of results
            var results = new SectorsResultsApiModel();

            // Add each centers details
            results.AddRange(result.Select(x => new SectorsApiModel
            {

                User = x.User,
                Id = x.Id,
                CategoryId = x.CategoryId,
                SectorId = x.SectorId,
                DateReported = x.DateReported,
                SectorTitle = x.SectorTitle,
                TimeStamp = x.TimeStamp,
                SectorName = x.SectorName,
                CategoryName = x.CategoryName
            }));


            return Task.FromResult(results);
        }

        public async Task SaveSectorsAsync(SectorsResultsApiModel sectors)
        {
            // Clear all entries
            mDbContext.Sectors.RemoveRange(mDbContext.Sectors);

            // Create a new list of results
            var results = new SectorsResultsApiModel();

            // Add each sectors details
            results.AddRange(sectors.Select(x => new SectorsApiModel
            {

                User = x.User,
                Id = x.Id,
                CategoryId = x.CategoryId,
                SectorId = x.SectorId,
                DateReported = x.DateReported,
                SectorTitle = x.SectorTitle,
                TimeStamp = x.TimeStamp,
                SectorName = x.SectorName,
                CategoryName = x.CategoryName

            }));

            // Add new one
            mDbContext.Sectors.AddRange(results);

            // Save changes
            await mDbContext.SaveChangesAsync();
        }

        public async Task ClearAllSectorsAsync()
        {
            // Clear all entries
            mDbContext.Sectors.RemoveRange(mDbContext.Sectors);

            // Save changes
            await mDbContext.SaveChangesAsync();
        }

        #endregion

        #region Reports

        public Task<ReportsResultsApiModel> GetReportsAsync()
        {
            // Get the list of projects
            var result = mDbContext.Reports.Take(100).ToList();

            // Create a new list of results
            var results = new ReportsResultsApiModel();

            // Add each centers details
            results.AddRange(result.Select(report => new ReportApiModel
            {

                Anonymous = report.Anonymous,
                ClientId = report.ClientId,
                Id = report.Id,
                Comments = report.Comments,
                Completion = report.Completion,
                ContractorName = report.ContractorName,
                ProjectName = report.ProjectName,
                DateReported = report.DateReported,
                LogoName = report.LogoName,
                ProjectId = report.ProjectId,
                Quality = report.Quality,
                ReportId = report.ReportId,
                Status = report.Status,
                TimeStamp = report.TimeStamp,
                User = report.User

            }));


            return Task.FromResult(results);
        }


        public Task<ReportApiModel> GetReportByIdAsync(int id)
        {
            // Get the list of projects
            var result = mDbContext.Reports.Find(id);

            var a = result;

            return Task.FromResult(result);
        }

        public async Task SaveReportsAsync(ReportsResultsApiModel reports)
        {
            // Clear all entries
            mDbContext.Reports.RemoveRange(mDbContext.Reports);

            // Create a new list of results
            var results = new ReportsResultsApiModel();

            // Add each sectors details
            results.AddRange(reports.Select(report => new ReportApiModel
            {

                Anonymous = report.Anonymous,
                ClientId = report.ClientId,
                Comments = report.Comments,
                Completion = report.Completion,
                ContractorName = report.ContractorName,
                ProjectName = report.ProjectName,
                DateReported = report.DateReported,
                LogoName = report.LogoName,
                ProjectId = report.ProjectId,
                Quality = report.Quality,
                ReportId = report.Id,
                Status = report.Status,
                TimeStamp = report.TimeStamp,
                User = report.User

            }));

            // Add new one
            mDbContext.Reports.AddRange(results);

            // Save changes
            await mDbContext.SaveChangesAsync();
        }

        public async Task DeleteReportAsync(ReportApiModel report)
        {
            // Clear all entries
            mDbContext.Reports.Remove(report);

            // Save changes
            await mDbContext.SaveChangesAsync();
        }

        public async Task UpdateReportAsync(ReportApiModel report)
        {
            // Clear all entries
            mDbContext.Reports.Update(report);

            // Save changes
            await mDbContext.SaveChangesAsync();
        }

        public async Task ClearAllReportsAsync()
        {
            // Clear all entries
            mDbContext.Reports.RemoveRange(mDbContext.Reports);

            // Save changes
            await mDbContext.SaveChangesAsync();
        }

        #endregion


        #endregion
    }
}
