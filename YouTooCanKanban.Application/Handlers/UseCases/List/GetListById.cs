using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using YouTooCanKanban.Application.Handlers.Base;
using YouTooCanKanban.Application.Handlers.Base.GenericQueries;
using YouTooCanKanban.BLL.Services;
using YouTooCanKanban.Domain.Models;

namespace YouTooCanKanban.Application.Handlers.UseCases.List
{
    public sealed class GetListByIdQuery : GetByIdQuery<ListModel>
    {
        public GetListByIdQuery() { }

        public GetListByIdQuery(int id) : base(id) { }
    }

    public sealed class GetListByIdQueryValidator : AbstractValidator<GetListByIdQuery>
    {
        public GetListByIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }

    public sealed class GetListByIdHandler : BaseQueryHandler<GetListByIdHandler, GetListByIdQuery, ListModel>
    {
        private readonly IListService ListService;

        public GetListByIdHandler(
            ILogger<GetListByIdHandler> logger,
            IListService Listervice
        ) : base(logger)
        {
            ListService = Listervice;
        }

        protected async override Task<Result<ListModel?>> Act(GetListByIdQuery request, CancellationToken cancellationToken)
        {
            return await ListService.GetById(request.Id, cancellationToken);
        }
    }
}
