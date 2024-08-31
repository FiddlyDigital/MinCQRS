﻿using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using YouTooCanKanban.Application.Handlers.Base;
using YouTooCanKanban.Application.Handlers.Base.GenericCommands;
using YouTooCanKanban.BLL.Services;
using YouTooCanKanban.DAL.Data.Interfaces;
using YouTooCanKanban.Domain.Models;

namespace YouTooCanKanban.Application.Handlers.UseCases.List
{
    public sealed class UpdateListCommand : UpdateCommand<ListModel>
    {
        public UpdateListCommand() { }

        public UpdateListCommand(ListModel List) : base(List) { }
    }

    public sealed class UpdateListCommandValidator : AbstractValidator<UpdateListCommand>
    {
        public UpdateListCommandValidator()
        {
            RuleFor(x => x.Model).NotNull();
            RuleFor(x => x.Model.Id).GreaterThanOrEqualTo(1);
            RuleFor(x => x.Model.Name).NotNull().NotEmpty();
            RuleFor(x => x.Model.BoardId).GreaterThanOrEqualTo(1);
        }
    }

    public sealed class UpdateListHandler : BaseCommandHandler<UpdateListHandler, UpdateListCommand, ListModel>
    {
        private readonly IListService ListService;

        public UpdateListHandler(
            ILogger<UpdateListHandler> logger,
            IUnitOfWork unitOfWork,
            IListService ListService
        ) : base(logger, unitOfWork)
        {
            this.ListService = ListService;
        }

        protected async override Task<Result<ListModel?>> Act(UpdateListCommand request, CancellationToken cancellationToken)
        {
            await ListService.Update(request.Model, cancellationToken);
            return null;
        }
    }
}
