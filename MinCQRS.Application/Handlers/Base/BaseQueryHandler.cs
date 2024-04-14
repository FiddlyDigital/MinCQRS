using LanguageExt.Common;
using MediatR;
using Microsoft.Extensions.Logging;
using MinCQRS.Application.Handlers.Base.Interfaces;

namespace MinCQRS.Application.Handlers.Base
{
    public abstract class BaseQueryHandler<THandler, TRequestQuery, TResponse> : IRequestHandler<TRequestQuery, Result<TResponse>>
           where TRequestQuery : IQuery<Result<TResponse>>
    {
        protected readonly ILogger<THandler> Logger;

        public BaseQueryHandler(ILogger<THandler> logger)
        {
            this.Logger = logger;
        }

        protected abstract Task<Result<TResponse?>> Act(TRequestQuery request, CancellationToken cancellationToken);

        public async Task<Result<TResponse>> Handle(TRequestQuery request, CancellationToken cancellationToken)
        {
            Result<TResponse?> result;

            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                result = await Act(request, cancellationToken);

                if (!result.IsSuccess)
                {
                    Exception exc = result.Match(
                        Succ: x => new Exception("Query did not succeed but no exception raised."), 
                        Fail: ex => ex
                    );

                    Logger.LogError(exc, "Handler unable to perform action and persist.");
                }
            }
            catch (Exception exc)
            {
                Logger.LogError(exc, "Handler unable to perform action and persist.");
                throw;
            }

            return await Task.FromResult(result);
        }
    }
}
