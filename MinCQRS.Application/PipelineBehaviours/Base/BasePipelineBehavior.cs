﻿namespace MinCQRS.Application.PipelineBehaviours.Base
{
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using MinCQRS.Application.Handlers.Base.Interfaces;

    public abstract class BasePipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : class, ICommand<TResponse>
    {
        public virtual Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            return Act(request, next, cancellationToken);
        }

        protected abstract Task<TResponse> Act(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken);

        public T CreateResponseObject<T>(params object[] parameters)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8603 // Possible null reference return.
            return (T)Activator.CreateInstance(typeof(T), bindingAttr: BindingFlags.Instance | BindingFlags.Public, null, parameters, null);
#pragma warning restore CS8603 // Possible null reference return.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
        }
    }
}
