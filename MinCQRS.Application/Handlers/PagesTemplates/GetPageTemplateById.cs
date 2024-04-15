using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using MinCQRS.Application.Handlers.Base;
using MinCQRS.Application.Handlers.Base.GenericQueries;
using MinCQRS.BLL.Services;
using MinCQRS.Domain.Models;

namespace MinCQRS.Application.Handlers.PageTemplate
{
    public sealed class GetPageTemplateByIdQuery : GetByIdQuery<PageTemplateModel>
    {
        public GetPageTemplateByIdQuery() { }

        public GetPageTemplateByIdQuery(int id) : base(id) { }
    }

    public sealed class GetPageTemplateByIdQueryValidator : AbstractValidator<GetPageTemplateByIdQuery>
    {
        public GetPageTemplateByIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }

    public sealed class GetPageTemplateByIdHandler : BaseQueryHandler<GetPageTemplateByIdHandler, GetPageTemplateByIdQuery, PageTemplateModel>
    {
        private readonly IPageTemplateService PageTemplateService;

        public GetPageTemplateByIdHandler(
            ILogger<GetPageTemplateByIdHandler> logger,
            IPageTemplateService PageTemplateervice
        ) : base(logger)
        {
            this.PageTemplateService = PageTemplateervice;
        }

        protected async override Task<Result<PageTemplateModel?>> Act(GetPageTemplateByIdQuery request, CancellationToken cancellationToken)
        {
            return await PageTemplateService.GetById(request.Id, cancellationToken);
        }
    }
}
