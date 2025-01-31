﻿namespace MinCQRS.Application.PipelineBehaviors
{
    using FluentValidation;
    using FluentValidation.Results;
    using MediatR;
    using MinCQRS.Application.PipelineBehaviours.Base;
    using MinCQRS.Application.Handlers.Base.Interfaces;

    public sealed class ValidationBehavior<TRequest, TResponse> : BasePipelineBehavior<TRequest, TResponse>
        where TRequest : class, ICommand<TResponse>
        where TResponse : new()
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            ArgumentNullException.ThrowIfNull(validators);
            this.validators = validators;
        }

        protected override Task<TResponse> Act(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            ValidationContext<TRequest> context = new ValidationContext<TRequest>(request);

            IEnumerable<ValidationFailure> failures = this.validators
                .Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .Where(x => x != null);

            if (failures.Any())
            {
                // usage
                ValidationException errorException = new ValidationException(failures);
                return Task.FromResult(CreateResponseObject<TResponse>(errorException));
            }

            return next();
        }
    }
}
