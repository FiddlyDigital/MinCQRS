using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using MinCQRS.Application.Handlers.Base;
using MinCQRS.Application.Handlers.Base.GenericQueries;
using MinCQRS.BLL.Services;
using MinCQRS.Domain.Models;

namespace MinCQRS.Application.Handlers.Microsites
{
    public sealed class GetMicrositeListQuery : GetListQuery<MicrositeModel>
    {
        public GetMicrositeListQuery() : base() { }

        public GetMicrositeListQuery(int pageIndex, int pageSize) : base(pageIndex, pageSize) { }
    }

    public sealed class GetMicrositeListQueryValidator : AbstractValidator<GetMicrositeListQuery>
    {
        public GetMicrositeListQueryValidator()
        {
            RuleFor(x => x.PageIndex).GreaterThan(-1).LessThan(100);
            RuleFor(x => x.PageSize).GreaterThan(-1).LessThanOrEqualTo(50);
        }
    }

    public sealed class GetMicrositeListHandler : BaseQueryHandler<GetMicrositeListHandler, GetMicrositeListQuery, IEnumerable<MicrositeModel>>
    {
        private readonly IMicrositeService MicrositeService;

        public GetMicrositeListHandler(
            ILogger<GetMicrositeListHandler> logger,
            IMicrositeService MicrositeService
        ) : base(logger)
        {
            this.MicrositeService = MicrositeService;
        }

        protected async override Task<Result<IEnumerable<MicrositeModel>>> Act(GetMicrositeListQuery request, CancellationToken cancellationToken)
        {
            return await MicrositeService.GetList(request.PageIndex, request.PageSize);
        }
    }
}
