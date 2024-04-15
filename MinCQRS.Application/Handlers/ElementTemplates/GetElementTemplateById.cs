using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using MinCQRS.Application.Handlers.Base;
using MinCQRS.Application.Handlers.Base.GenericQueries;
using MinCQRS.BLL.Services;
using MinCQRS.Domain.Models;

namespace MinCQRS.Application.Handlers.ElementTemplates
{
    public sealed class GetElementTemplateByIdQuery : GetByIdQuery<ElementTemplateModel>
    {
        public GetElementTemplateByIdQuery() { }

        public GetElementTemplateByIdQuery(int id) : base(id) { }
    }

    public sealed class GetElementTemplateByIdQueryValidator : AbstractValidator<GetElementTemplateByIdQuery>
    {
        public GetElementTemplateByIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }

    public sealed class GetElementTemplateByIdHandler : BaseQueryHandler<GetElementTemplateByIdHandler, GetElementTemplateByIdQuery, ElementTemplateModel>
    {
        private readonly IElementTemplateService ElementTemplateService;

        public GetElementTemplateByIdHandler(
            ILogger<GetElementTemplateByIdHandler> logger,
            IElementTemplateService ElementTemplateService
        ) : base(logger)
        {
            this.ElementTemplateService = ElementTemplateService;
        }

        protected async override Task<Result<ElementTemplateModel?>> Act(GetElementTemplateByIdQuery request, CancellationToken cancellationToken)
        {
            return await ElementTemplateService.GetById(request.Id, cancellationToken);
        }
    }
}
