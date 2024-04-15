using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using MinCQRS.Application.Handlers.Base;
using MinCQRS.Application.Handlers.Base.GenericQueries;
using MinCQRS.BLL.Services;
using MinCQRS.Domain.Models;

namespace MinCQRS.Application.Handlers.BlockTemplate
{
    public sealed class GetBlockTemplateByIdQuery : GetByIdQuery<BlockTemplateModel>
    {
        public GetBlockTemplateByIdQuery() { }

        public GetBlockTemplateByIdQuery(int id) : base(id) { }
    }

    public sealed class GetBlockTemplateByIdQueryValidator : AbstractValidator<GetBlockTemplateByIdQuery>
    {
        public GetBlockTemplateByIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }

    public sealed class GetBlockTemplateByIdHandler : BaseQueryHandler<GetBlockTemplateByIdHandler, GetBlockTemplateByIdQuery, BlockTemplateModel>
    {
        private readonly IBlockTemplateService BlockTemplateService;

        public GetBlockTemplateByIdHandler(
            ILogger<GetBlockTemplateByIdHandler> logger,
            IBlockTemplateService BlockTemplateervice
        ) : base(logger)
        {
            this.BlockTemplateService = BlockTemplateervice;
        }

        protected async override Task<Result<BlockTemplateModel?>> Act(GetBlockTemplateByIdQuery request, CancellationToken cancellationToken)
        {
            return await BlockTemplateService.GetById(request.Id, cancellationToken);
        }
    }
}
