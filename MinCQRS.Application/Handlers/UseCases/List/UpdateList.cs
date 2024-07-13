using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using MinCQRS.Application.Handlers.Base.GenericQueries;
using MinCQRS.Application.Handlers.Base;
using MinCQRS.BLL.Services;
using MinCQRS.Domain.Models;
using MinCQRS.DAL.Data.Interfaces;

namespace MinCQRS.Application.Handlers.UseCases.List
{
    public sealed class UpdateListCommand : UpdateCommand<ListModel>
    {
        public UpdateListCommand() { }

        public UpdateListCommand(ListModel List) : base(List) { }
    }

    public sealed class UpdateListQueryValidator : AbstractValidator<UpdateListCommand>
    {
        public UpdateListQueryValidator()
        {
            RuleFor(x => x.Model).NotNull();
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
