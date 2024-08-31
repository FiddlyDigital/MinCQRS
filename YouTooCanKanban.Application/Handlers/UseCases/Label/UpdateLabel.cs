using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using YouTooCanKanban.Application.Handlers.Base;
using YouTooCanKanban.Application.Handlers.Base.GenericCommands;
using YouTooCanKanban.BLL.Services;
using YouTooCanKanban.DAL.Data.Interfaces;
using YouTooCanKanban.Domain.Models;

namespace YouTooCanKanban.Application.Handlers.UseCases.Label
{
    public sealed class UpdateLabelCommand : UpdateCommand<LabelModel>
    {
        public UpdateLabelCommand() { }

        public UpdateLabelCommand(LabelModel Label) : base(Label) { }
    }

    public sealed class UpdateLabelCommandValidator : AbstractValidator<UpdateLabelCommand>
    {
        public UpdateLabelCommandValidator()
        {
            RuleFor(x => x.Model).NotNull();
            RuleFor(x => x.Model.Id).GreaterThanOrEqualTo(1);
            RuleFor(x => x.Model.Name).NotNull().NotEmpty();
            RuleFor(x => x.Model.BoardId).GreaterThanOrEqualTo(1);
        }
    }

    public sealed class UpdateLabelHandler : BaseCommandHandler<UpdateLabelHandler, UpdateLabelCommand, LabelModel>
    {
        private readonly ILabelService LabelService;

        public UpdateLabelHandler(
            ILogger<UpdateLabelHandler> logger,
            IUnitOfWork unitOfWork,
            ILabelService LabelService
        ) : base(logger, unitOfWork)
        {
            this.LabelService = LabelService;
        }

        protected async override Task<Result<LabelModel?>> Act(UpdateLabelCommand request, CancellationToken cancellationToken)
        {
            await LabelService.Update(request.Model, cancellationToken);
            return null;
        }
    }
}
