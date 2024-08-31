using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using YouTooCanKanban.Application.Handlers.Base;
using YouTooCanKanban.Application.Handlers.Base.GenericCommands;
using YouTooCanKanban.BLL.Services;
using YouTooCanKanban.DAL.Data.Interfaces;
using YouTooCanKanban.Domain.Models;

namespace YouTooCanKanban.Application.Handlers.UseCases.List
{
    public sealed class CreateListCommand : CreateCommand<ListModel>
    {
        public CreateListCommand() { }

        public CreateListCommand(ListModel List) : base(List) { }
    }

    public sealed class CreateListCommandValidator : AbstractValidator<CreateListCommand>
    {
        public CreateListCommandValidator()
        {
            RuleFor(x => x.Model).NotNull();
            RuleFor(x => x.Model.Id).LessThanOrEqualTo(0).GreaterThanOrEqualTo(-1);
            RuleFor(x => x.Model.Name).NotNull().NotEmpty();
            RuleFor(x => x.Model.BoardId).GreaterThanOrEqualTo(1);
        }
    }

    public sealed class CreateListHandler : BaseCommandHandler<CreateListHandler, CreateListCommand, ListModel>
    {
        private readonly IListService ListService;

        public CreateListHandler(
            ILogger<CreateListHandler> logger,
            IUnitOfWork unitOfWork,
            IListService ListService
        ) : base(logger, unitOfWork)
        {
            this.ListService = ListService;
        }

        protected async override Task<Result<ListModel?>> Act(CreateListCommand request, CancellationToken cancellationToken)
        {
            return await ListService.Create(request.Model, cancellationToken);
        }
    }
}
