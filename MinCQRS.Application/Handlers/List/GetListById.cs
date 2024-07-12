using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using MinCQRS.Application.Handlers.Base;
using MinCQRS.Application.Handlers.Base.GenericQueries;
using MinCQRS.BLL.Services;
using MinCQRS.Domain.Models;

namespace MinCQRS.Application.Handlers.List
{
    public sealed class GetListByIdQuery : GetByIdQuery<ListModel>
    {
        public GetListByIdQuery() { }

        public GetListByIdQuery(int id) : base(id) { }
    }

    public sealed class GetListByIdQueryValidator : AbstractValidator<GetListByIdQuery>
    {
        public GetListByIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }

    public sealed class GetListByIdHandler : BaseQueryHandler<GetListByIdHandler, GetListByIdQuery, ListModel>
    {
        private readonly IListService ListService;

        public GetListByIdHandler(
            ILogger<GetListByIdHandler> logger,
            IListService Listervice
        ) : base(logger)
        {
            this.ListService = Listervice;
        }

        protected async override Task<Result<ListModel?>> Act(GetListByIdQuery request, CancellationToken cancellationToken)
        {
            return await ListService.GetById(request.Id, cancellationToken);
        }
    }
}
