namespace MinCQRS.BLL.Services.Base
{
    using Microsoft.Extensions.Logging;

    public abstract class BaseService<T> where T : BaseService<T>
    {
        protected readonly ILogger Logger;

        protected BaseService(ILogger<T> logger)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}
