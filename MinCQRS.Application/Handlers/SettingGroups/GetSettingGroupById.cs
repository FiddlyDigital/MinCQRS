using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using MinCQRS.Application.Handlers.Base;
using MinCQRS.Application.Handlers.Base.GenericQueries;
using MinCQRS.BLL.Services;
using MinCQRS.Domain.Models;

namespace MinCQRS.Application.Handlers.SettingGroups
{
    public sealed class GetSettingGroupByIdQuery : GetByIdQuery<SettingGroupModel>
    {
        public GetSettingGroupByIdQuery(int id) : base(id) { }
    }

    public sealed class GetSettingGroupByIdQueryValidator : AbstractValidator<GetSettingGroupByIdQuery>
    {
        public GetSettingGroupByIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }

    public sealed class GetSettingGroupByIdHandler : BaseQueryHandler<GetSettingGroupByIdHandler, GetSettingGroupByIdQuery, SettingGroupModel>
    {
        private readonly ISettingGroupService settingGroupService;

        public GetSettingGroupByIdHandler(
            ILogger<GetSettingGroupByIdHandler> logger,
            ISettingGroupService settingGroupService
        ) : base(logger)
        {
            this.settingGroupService = settingGroupService;
        }

        protected async override Task<Result<SettingGroupModel?>> Act(GetSettingGroupByIdQuery request, CancellationToken cancellationToken)
        {
            return await settingGroupService.GetById(request.Id, cancellationToken);
        }
    }
}
