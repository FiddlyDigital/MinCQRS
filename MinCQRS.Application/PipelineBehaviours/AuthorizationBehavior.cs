using MediatR;
using MinCQRS.Application.PipelineBehaviours.Base;
using MinCQRS.Application.Handlers.Base.Interfaces;

namespace MinCQRS.Application.PipelineBehaviors
{
    public sealed class AuthorizationBehavior<TRequest, TResponse> : BasePipelineBehavior<TRequest, TResponse>
        where TRequest : class, ICommand<TResponse>
        where TResponse : new()
    {

        public AuthorizationBehavior()
        {
        }

        /// <inheritdoc />
        protected override Task<TResponse> Act(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // TODO: fill in later
            return next();
        }
    }
}
