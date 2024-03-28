namespace MinCQRS.DAL.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using MinCQRS.DAL.Entities;

    public class BaseDBContext : DbContext
    {
        private readonly ILogger<BaseDBContext> _logger;

        public BaseDBContext(DbContextOptions<BaseDBContext> contextOptions, ILogger<BaseDBContext> logger) : base(contextOptions)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _logger.LogDebug("Context Initialized");
        }

        public virtual DbSet<SettingGroupEntity> SettingGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SettingGroupEntity>().HasQueryFilter(r => !r.IsDeleted);
            modelBuilder.Entity<SettingGroupEntity>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
        }
    }
}
