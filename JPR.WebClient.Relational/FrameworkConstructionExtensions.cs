using Dna;
using jpr.core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace jpr.Relational
{
    /// <summary>
    /// Extension methods for the <see cref="FrameworkConstruction"/>
    /// </summary>
    public static class FrameworkConstructionExtensions
    {


        /// <summary>
        /// Default constructor
        /// </summary>
        public static IServiceCollection AddClientDataStore(this IServiceCollection services, string dbPath)
        {

            // Inject our SQLite EF data store
            services.AddDbContext<ClientDataStoreDbContext>(options =>
            {
                // Setup connection string
                options.UseSqlite($"Data Source={dbPath}.db");
            }, contextLifetime: ServiceLifetime.Transient);

            // Add client data store for easy access/use of the backing data store
            // Make it scoped so we can inject the scoped DbContext
            services.AddTransient<IClientDataStore>(
                provider => new BaseClientDataStore(provider.GetService<ClientDataStoreDbContext>()));

            // Return framework for chaining
            return services;
        }
    }
}
