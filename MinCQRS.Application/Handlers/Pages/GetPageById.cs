using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using MinCQRS.Application.Handlers.Base;
using MinCQRS.Application.Handlers.Base.GenericQueries;
using MinCQRS.BLL.Services;
using MinCQRS.Domain.Models;

namespace MinCQRS.Application.Handlers.Page
{
    public sealed class GetPageByIdQuery : GetByIdQuery<PageModel>
    {
        public GetPageByIdQuery() { }

        public GetPageByIdQuery(int id) : base(id) { }
    }

    public sealed class GetPageByIdQueryValidator : AbstractValidator<GetPageByIdQuery>
    {
        public GetPageByIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }

    public sealed class GetPageByIdHandler : BaseQueryHandler<GetPageByIdHandler, GetPageByIdQuery, PageModel>
    {
        private readonly IPageService PageService;

        public GetPageByIdHandler(
            ILogger<GetPageByIdHandler> logger,
            IPageService Pageervice
        ) : base(logger)
        {
            this.PageService = Pageervice;
        }

        protected async override Task<Result<PageModel?>> Act(GetPageByIdQuery request, CancellationToken cancellationToken)
        {
            return await PageService.GetById(request.Id, cancellationToken);
        }
    }
}
