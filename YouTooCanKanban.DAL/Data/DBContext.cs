using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using YouTooCanKanban.DAL.Entities;

namespace YouTooCanKanban.DAL.Data
{
    public class BaseDBContext : DbContext
    {
        private readonly ILogger<BaseDBContext> _logger;

        public BaseDBContext(DbContextOptions<BaseDBContext> contextOptions, ILogger<BaseDBContext> logger) : base(contextOptions)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _logger.LogDebug("Context Initialized");
        }

        public virtual DbSet<BoardEntity> Boards { get; set; }

        public virtual DbSet<CardEntity> Cards { get; set; }

        public virtual DbSet<ListEntity> Lists { get; set; }

        public virtual DbSet<WorkspaceEntity> Workspaces { get; set; }

        public virtual DbSet<LabelEntity> Labels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
