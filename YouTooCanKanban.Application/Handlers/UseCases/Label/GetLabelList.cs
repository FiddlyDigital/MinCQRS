using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using YouTooCanKanban.Application.Handlers.Base;
using YouTooCanKanban.Application.Handlers.Base.GenericQueries;
using YouTooCanKanban.BLL.Services;
using YouTooCanKanban.Domain.Models;

namespace YouTooCanKanban.Application.Handlers.UseCases.Label
{
    public sealed class GetLabelListQuery : GetListQuery<LabelModel>
    {
        public GetLabelListQuery() : base() { }

        public GetLabelListQuery(int pageIndex, int pageSize, string? sortBy, string? sortDir, string? filter) : base(pageIndex, pageSize, sortBy, sortDir, filter) { }
    }

    public sealed class GetLabelListQueryValidator : AbstractValidator<GetLabelListQuery>
    {
        public GetLabelListQueryValidator()
        {
            RuleFor(x => x.PageIndex).GreaterThan(-1);
            RuleFor(x => x.PageSize).GreaterThan(-1).LessThanOrEqualTo(50);
        }
    }

    public sealed class GetLabelListHandler : BaseQueryHandler<GetLabelListHandler, GetLabelListQuery, IEnumerable<LabelModel>>
    {
        private readonly ILabelService LabelService;

        public GetLabelListHandler(
            ILogger<GetLabelListHandler> logger,
            ILabelService LabelService
        ) : base(logger)
        {
            this.LabelService = LabelService;
        }

        protected async override Task<Result<IEnumerable<LabelModel>>> Act(GetLabelListQuery request, CancellationToken cancellationToken)
        {
            return await LabelService.GetList(request.PageIndex, request.PageSize, request.SortBy, request.SortDir, request.Filter);
        }
    }
}
