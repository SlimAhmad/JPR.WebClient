using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace JPR.WebClient
{
    /// <summary>
    /// Extension methods for the <see cref="FrameworkConstruction"/>
    /// </summary>
    public static class FrameworkConstructionExtensions
    {
        /// <summary>
        /// Injects the repositories needed for the jpr application
        /// </summary>
        /// <param name="construction"></param>
        /// <returns></returns>
        public static IServiceCollection AddJPRClientServices(this IServiceCollection services)
        {
            services.AddHttpClient<IUserService, UserService>();
            services.AddHttpClient<IProjectService, ProjectService>();
            services.AddHttpClient<IReportService, ReportService>();
            services.AddHttpClient<ISectorService, SectorService>();
            services.AddHttpClient<ISectorTypeService, SectorTypeService>();
            services.AddHttpClient<IRoleService, RoleService>();
            services.AddHttpClient<ICategoryService, CategoryService>();
            services.AddHttpClient<IContractorService, ContractorService>();
            services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
            //services.AddBlazoredModal();

            // Return the construction for chaining
            return services;
        }

    }
}
