namespace MinCQRS.Application.Handlers.Base
{
    using LanguageExt.Common;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using MinCQRS.Application.Handlers.Base.Interfaces;
    using MinCQRS.DAL.Data.Interfaces;
    using System;
    using System.Threading.Tasks;

    public abstract class BaseCommandHandler<THandler, TRequestCommand, TResponse> : IRequestHandler<TRequestCommand, Result<TResponse>>
       where TRequestCommand : ICommand<Result<TResponse>>
    {
        protected readonly ILogger<THandler> Logger;
        private readonly IUnitOfWork unitOfWork;

        public BaseCommandHandler(
            ILogger<THandler> logger,
            IUnitOfWork unitOfWork)
        {
            this.Logger = logger;
            this.unitOfWork = unitOfWork;
        }

        protected abstract Task<Result<TResponse>> Act(TRequestCommand request, CancellationToken cancellationToken);

        public async Task<Result<TResponse>> Handle(TRequestCommand request, CancellationToken cancellationToken)
        {
            Result<TResponse> result;

            try
            {
                await unitOfWork.BeginTransactionAsync(cancellationToken);
                result = await Act(request, cancellationToken);

                if (!result.IsSuccess)
                {
                    Exception exc = result.Match(
                        Succ: x => new Exception("Command did not succeed but no exception raised."),
                        Fail: ex => ex
                    );

                    Logger.LogError(exc, "Handler unable to perform action and persist.");
                    await unitOfWork.RollbackTransactionAsync(cancellationToken);
                }
                else
                {
                    await unitOfWork.CommitTransactionAsync(cancellationToken);
                }
            }
            catch (Exception exc)
            {
                Logger.LogError(exc, "Handler unable to perform action and persist.");
                await unitOfWork.RollbackTransactionAsync(cancellationToken);
                throw;
            }

            return await Task.FromResult(result);
        }

        protected static Result<TOut> ReturnFailResult<TOut>(Exception exception)
        {
            if (exception is System.ComponentModel.DataAnnotations.ValidationException)
            {
                return new Result<TOut>(new FluentValidation.ValidationException(exception.GetBaseException().Message));
            }

            return new Result<TOut>(exception);
        }
    }
}
