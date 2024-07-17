using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace YouTooCanKanban.DAL.Data
{
    public class BaseDBContextFactory : IDesignTimeDbContextFactory<BaseDBContext>
    {
        private readonly ILogger<BaseDBContext> logger;

        // Only exists for generating migrations
        public BaseDBContextFactory()
        {
            this.logger = new Logger<BaseDBContext>(LoggerFactory.Create(builder =>
            {
                builder.AddFilter("Microsoft", LogLevel.Warning)
                       .AddFilter("System", LogLevel.Warning)
                       .AddFilter("YouTooCanKanban.DAL", LogLevel.Debug);
            }));
        }

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
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DBConn"), builder => builder.MigrationsAssembly("YouTooCanKanban.DAL"));
            return new BaseDBContext(optionsBuilder.Options, logger);
#else
            var optionsBuilder = new DbContextOptionsBuilder<BaseDBContext>();
            optionsBuilder.UseSqlServer();
            return new BaseDBContext(optionsBuilder.Options, logger);
#endif
        }
    }
}
