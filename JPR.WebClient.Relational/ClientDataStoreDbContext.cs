using jpr.core;
using Microsoft.EntityFrameworkCore;

namespace jpr.Relational
{
    /// <summary>
    /// The database context for the client data store
    /// </summary>
    public class ClientDataStoreDbContext : DbContext
    {
        #region DbSets 

        /// <summary>
        /// The client login credentials
        /// </summary>
        public DbSet<LoginCredentialsDataModel> LoginCredentials { get; set; }

        /// <summary>
        /// The client projects
        /// </summary>
        public DbSet<ProjectsApiModel> Projects { get; set; }


        /// <summary>
        /// The client Sectors
        /// </summary>
        public DbSet<SectorsApiModel> Sectors { get; set; }

        /// <summary>
        /// The client Reports
        /// </summary>
        public DbSet<ReportApiModel> Reports { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ClientDataStoreDbContext(DbContextOptions<ClientDataStoreDbContext> options) : base(options) { }


        #endregion

        #region Model Creating

        /// <summary>
        /// Configures the database structure and relationships
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API

            // Configure LoginCredentials
            // --------------------------
            //
            // Set Id as primary key
            modelBuilder.Entity<LoginCredentialsDataModel>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).ValueGeneratedOnAdd();
            });


            // Fluent API

            // Configure Projects
            // --------------------------
            //
            // Set Id as primary key
            modelBuilder.Entity<ProjectsApiModel>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(x => x.Id).ValueGeneratedOnAdd();
            });

            // Fluent API

            // Configure Sectors
            // --------------------------
            //
            // Set Id as primary key
            modelBuilder.Entity<SectorsApiModel>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(x => x.Id).ValueGeneratedOnAdd();
            });


            // Fluent API

            // Configure reports
            // --------------------------
            //
            // Set Id as primary key
            modelBuilder.Entity<ReportApiModel>().HasKey(x => x.Id);

            // TODO: Set up limits
            //modelBuilder.Entity<LoginCredentialsDataModel>().Property(a => a.FirstName).HasMaxLength(50);
        }

        #endregion
    }
}
