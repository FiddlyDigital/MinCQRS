using MediatR;
using YouTooCanKanban.Application.PipelineBehaviors.Base;
using YouTooCanKanban.Application.Handlers.Base.Interfaces;

namespace YouTooCanKanban.Application.PipelineBehaviors
{
    public sealed class AuthorizationBehavior<TRequest, TResponse> : BasePipelineBehavior<TRequest, TResponse>
        where TRequest : class, ICommand<TResponse>
        where TResponse : new()
    {

        public AuthorizationBehavior() { }

        /// <inheritdoc />
        protected override Task<TResponse> Act(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // TODO: fill in later
            return next();
        }
    }
}
