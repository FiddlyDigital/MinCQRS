using Microsoft.Extensions.Logging;

namespace YouTooCanKanban.Domain
{
    public abstract class BaseService<T> where T : BaseService<T>
    {
        protected readonly ILogger _logger;

        protected BaseService(ILogger<T> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}
