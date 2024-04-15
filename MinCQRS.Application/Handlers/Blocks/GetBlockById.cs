using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using MinCQRS.Application.Handlers.Base;
using MinCQRS.Application.Handlers.Base.GenericQueries;
using MinCQRS.BLL.Services;
using MinCQRS.Domain.Models;

namespace MinCQRS.Application.Handlers.Block
{
    public sealed class GetBlockByIdQuery : GetByIdQuery<BlockModel>
    {
        public GetBlockByIdQuery() { }

        public GetBlockByIdQuery(int id) : base(id) { }
    }

    public sealed class GetBlockByIdQueryValidator : AbstractValidator<GetBlockByIdQuery>
    {
        public GetBlockByIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }

    public sealed class GetBlockByIdHandler : BaseQueryHandler<GetBlockByIdHandler, GetBlockByIdQuery, BlockModel>
    {
        private readonly IBlockService BlockService;

        public GetBlockByIdHandler(
            ILogger<GetBlockByIdHandler> logger,
            IBlockService Blockervice
        ) : base(logger)
        {
            this.BlockService = Blockervice;
        }

        protected async override Task<Result<BlockModel?>> Act(GetBlockByIdQuery request, CancellationToken cancellationToken)
        {
            return await BlockService.GetById(request.Id, cancellationToken);
        }
    }
}
