﻿using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using MinCQRS.Application.Handlers.Base.GenericQueries;
using MinCQRS.Application.Handlers.Base;
using MinCQRS.BLL.Services;
using MinCQRS.Domain.Models;
using MinCQRS.DAL.Data.Interfaces;

namespace MinCQRS.Application.Handlers.UseCases.List
{
    public sealed class DeleteListCommand : DeleteCommand<ListModel>
    {
        public DeleteListCommand() { }

        public DeleteListCommand(int id) : base(id) { }
    }

    public sealed class DeleteListQueryValidator : AbstractValidator<DeleteListCommand>
    {
        public DeleteListQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }

    public sealed class DeleteListHandler : BaseCommandHandler<DeleteListHandler, DeleteListCommand, ListModel>
    {
        private readonly IListService ListService;

        public DeleteListHandler(
            ILogger<DeleteListHandler> logger,
            IUnitOfWork unitOfWork,
            IListService ListService
        ) : base(logger, unitOfWork)
        {
            this.ListService = ListService;
        }

        protected async override Task<Result<ListModel?>> Act(DeleteListCommand request, CancellationToken cancellationToken)
        {
            await ListService.Delete(request.Id, cancellationToken);
            return null;
        }
    }
}
