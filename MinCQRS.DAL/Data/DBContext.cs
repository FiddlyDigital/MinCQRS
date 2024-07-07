using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MinCQRS.DAL.Entities;

namespace MinCQRS.DAL.Data
{
    public class BaseDBContext : DbContext
    {
        private readonly ILogger<BaseDBContext> _logger;

        public BaseDBContext(DbContextOptions<BaseDBContext> contextOptions, ILogger<BaseDBContext> logger) : base(contextOptions)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _logger.LogDebug("Context Initialized");
        }

        public virtual DbSet<WorkspaceEntity> Workspaces { get; set; }
        public virtual DbSet<BoardEntity> Boards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
