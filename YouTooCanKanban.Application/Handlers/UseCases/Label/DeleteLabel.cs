﻿using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using YouTooCanKanban.Application.Handlers.Base.GenericQueries;
using YouTooCanKanban.Application.Handlers.Base;
using YouTooCanKanban.BLL.Services;
using YouTooCanKanban.Domain.Models;
using YouTooCanKanban.DAL.Data.Interfaces;

namespace YouTooCanKanban.Application.Handlers.UseCases.Label
{
    public sealed class DeleteLabelCommand : DeleteCommand<LabelModel>
    {
        public DeleteLabelCommand() { }

        public DeleteLabelCommand(int id) : base(id) { }
    }

    public sealed class DeleteLabelQueryValidator : AbstractValidator<DeleteLabelCommand>
    {
        public DeleteLabelQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }

    public sealed class DeleteLabelHandler : BaseCommandHandler<DeleteLabelHandler, DeleteLabelCommand, LabelModel>
    {
        private readonly ILabelService LabelService;

        public DeleteLabelHandler(
            ILogger<DeleteLabelHandler> logger,
            IUnitOfWork unitOfWork,
            ILabelService LabelService
        ) : base(logger, unitOfWork)
        {
            this.LabelService = LabelService;
        }

        protected async override Task<Result<LabelModel?>> Act(DeleteLabelCommand request, CancellationToken cancellationToken)
        {
            await LabelService.Delete(request.Id, cancellationToken);
            return null;
        }
    }
}
