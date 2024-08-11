using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using YouTooCanKanban.Application.Handlers.Base;
using YouTooCanKanban.Application.Handlers.Base.GenericQueries;
using YouTooCanKanban.BLL.Services;
using YouTooCanKanban.Domain.Models;

namespace YouTooCanKanban.Application.Handlers.UseCases.Label
{
    public sealed class GetLabelByIdQuery : GetByIdQuery<LabelModel>
    {
        public GetLabelByIdQuery() { }

        public GetLabelByIdQuery(int id) : base(id) { }
    }

    public sealed class GetLabelByIdQueryValidator : AbstractValidator<GetLabelByIdQuery>
    {
        public GetLabelByIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }

    public sealed class GetLabelByIdHandler : BaseQueryHandler<GetLabelByIdHandler, GetLabelByIdQuery, LabelModel>
    {
        private readonly ILabelService LabelService;

        public GetLabelByIdHandler(
            ILogger<GetLabelByIdHandler> logger,
            ILabelService Labelervice
        ) : base(logger)
        {
            LabelService = Labelervice;
        }

        protected async override Task<Result<LabelModel?>> Act(GetLabelByIdQuery request, CancellationToken cancellationToken)
        {
            return await LabelService.GetById(request.Id, cancellationToken);
        }
    }
}
