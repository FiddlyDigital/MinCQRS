namespace MinCQRS.DAL.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    public class BaseDBContextFactory : IDesignTimeDbContextFactory<BaseDBContext>
    {
        private readonly ILogger<BaseDBContext> logger;

        public BaseDBContextFactory(ILogger<BaseDBContext> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public BaseDBContext CreateDbContext(string[] args)
        {
#if DEBUG
            // For dev builds - to be able to run migrations and updates using visual studio
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<BaseDBContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DBConn"));
            return new BaseDBContext(optionsBuilder.Options, logger);
#else
            // For release builds - to be able to run migrations and updates using azure piplines with EF Migration Bundles
            var optionsBuilder = new DbContextOptionsBuilder<BaseDBContext>();
            optionsBuilder.UseSqlServer();
            return new BaseDBContext(optionsBuilder.Options, logger);
#endif
        }
    }
}
