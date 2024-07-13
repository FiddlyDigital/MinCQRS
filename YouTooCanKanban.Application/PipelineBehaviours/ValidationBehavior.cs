using FluentValidation;
using FluentValidation.Results;
using MediatR;
using YouTooCanKanban.Application.PipelineBehaviours.Base;

namespace YouTooCanKanban.Application.PipelineBehaviors
{
    public sealed class ValidationBehavior<TRequest, TResponse> : BasePipelineBehavior<TRequest, TResponse>
        where TRequest : class, IRequest<TResponse>
        where TResponse : new()
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            // Force use of Validators
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
                ValidationException errorException = new ValidationException(failures);
                return Task.FromResult(CreateResponseObject<TResponse>(errorException));
            }

            return next();
        }
    }
}
