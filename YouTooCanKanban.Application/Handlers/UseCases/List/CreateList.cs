using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using YouTooCanKanban.Application.Handlers.Base.GenericQueries;
using YouTooCanKanban.Application.Handlers.Base;
using YouTooCanKanban.BLL.Services;
using YouTooCanKanban.Domain.Models;
using YouTooCanKanban.DAL.Data.Interfaces;

namespace YouTooCanKanban.Application.Handlers.UseCases.List
{
    public sealed class CreateListCommand : CreateCommand<ListModel>
    {
        public CreateListCommand() { }

        public CreateListCommand(ListModel List) : base(List) { }
    }

    public sealed class CreateListQueryValidator : AbstractValidator<CreateListCommand>
    {
        public CreateListQueryValidator()
        {
            RuleFor(x => x.Model).NotNull();
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
