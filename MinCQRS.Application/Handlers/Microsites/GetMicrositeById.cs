using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using MinCQRS.Application.Handlers.Base;
using MinCQRS.Application.Handlers.Base.GenericQueries;
using MinCQRS.BLL.Services;
using MinCQRS.Domain.Models;

namespace MinCQRS.Application.Handlers.Microsites
{
    public sealed class GetMicrositeByIdQuery : GetByIdQuery<MicrositeModel>
    {
        public GetMicrositeByIdQuery() { }

        public GetMicrositeByIdQuery(int id) : base(id) { }
    }

    public sealed class GetMicrositeByIdQueryValidator : AbstractValidator<GetMicrositeByIdQuery>
    {
        public GetMicrositeByIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }

    public sealed class GetMicrositeByIdHandler : BaseQueryHandler<GetMicrositeByIdHandler, GetMicrositeByIdQuery, MicrositeModel>
    {
        private readonly IMicrositeService MicrositeService;

        public GetMicrositeByIdHandler(
            ILogger<GetMicrositeByIdHandler> logger,
            IMicrositeService MicrositeService
        ) : base(logger)
        {
            this.MicrositeService = MicrositeService;
        }

        protected async override Task<Result<MicrositeModel?>> Act(GetMicrositeByIdQuery request, CancellationToken cancellationToken)
        {
            return await MicrositeService.GetById(request.Id, cancellationToken);
        }
    }
}
