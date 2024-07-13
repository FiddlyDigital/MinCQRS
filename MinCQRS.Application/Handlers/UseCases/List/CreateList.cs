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
