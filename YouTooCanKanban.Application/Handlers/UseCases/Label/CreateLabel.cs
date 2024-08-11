using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using YouTooCanKanban.Application.Handlers.Base.GenericQueries;
using YouTooCanKanban.Application.Handlers.Base;
using YouTooCanKanban.BLL.Services;
using YouTooCanKanban.Domain.Models;
using YouTooCanKanban.DAL.Data.Interfaces;

namespace YouTooCanKanban.Application.Handlers.UseCases.Label
{
    public sealed class CreateLabelCommand : CreateCommand<LabelModel>
    {
        public CreateLabelCommand() { }

        public CreateLabelCommand(LabelModel Label) : base(Label) { }
    }

    public sealed class CreateLabelQueryValidator : AbstractValidator<CreateLabelCommand>
    {
        public CreateLabelQueryValidator()
        {
            RuleFor(x => x.Model).NotNull();
            RuleFor(x => x.Model.Id).LessThanOrEqualTo(0).GreaterThanOrEqualTo(-1);
            RuleFor(x => x.Model.Name).NotNull().NotEmpty();
            RuleFor(x => x.Model.BoardId).GreaterThanOrEqualTo(1);
        }
    }

    public sealed class CreateLabelHandler : BaseCommandHandler<CreateLabelHandler, CreateLabelCommand, LabelModel>
    {
        private readonly ILabelService LabelService;

        public CreateLabelHandler(
            ILogger<CreateLabelHandler> logger,
            IUnitOfWork unitOfWork,
            ILabelService LabelService
        ) : base(logger, unitOfWork)
        {
            this.LabelService = LabelService;
        }

        protected async override Task<Result<LabelModel?>> Act(CreateLabelCommand request, CancellationToken cancellationToken)
        {
            return await LabelService.Create(request.Model, cancellationToken);
        }
    }
}
