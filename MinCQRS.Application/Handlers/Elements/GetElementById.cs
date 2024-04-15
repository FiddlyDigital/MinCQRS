using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using MinCQRS.Application.Handlers.Base;
using MinCQRS.Application.Handlers.Base.GenericQueries;
using MinCQRS.BLL.Services;
using MinCQRS.Domain.Models;

namespace MinCQRS.Application.Handlers.Element
{
    public sealed class GetElementByIdQuery : GetByIdQuery<ElementModel>
    {
        public GetElementByIdQuery() { }

        public GetElementByIdQuery(int id) : base(id) { }
    }

    public sealed class GetElementByIdQueryValidator : AbstractValidator<GetElementByIdQuery>
    {
        public GetElementByIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }

    public sealed class GetElementByIdHandler : BaseQueryHandler<GetElementByIdHandler, GetElementByIdQuery, ElementModel>
    {
        private readonly IElementService ElementService;

        public GetElementByIdHandler(
            ILogger<GetElementByIdHandler> logger,
            IElementService Elementervice
        ) : base(logger)
        {
            this.ElementService = Elementervice;
        }

        protected async override Task<Result<ElementModel?>> Act(GetElementByIdQuery request, CancellationToken cancellationToken)
        {
            return await ElementService.GetById(request.Id, cancellationToken);
        }
    }
}
