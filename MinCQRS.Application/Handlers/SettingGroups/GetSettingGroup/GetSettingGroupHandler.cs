namespace MinCQRS.Application.Handlers.SettingsGroups.GetSettingGroup
{
    using LanguageExt.Common;
    using Microsoft.Extensions.Logging;
    using MinCQRS.Application.Handlers.Base;
    using MinCQRS.Application.Handlers.SettingGroups.GetSettingGroup;
    using MinCQRS.BLL.Services.Interfaces;
    using MinCQRS.Domain.Models;

    public sealed class GetSettingGroupHandler : BaseQueryHandler<GetSettingGroupHandler, GetSettingGroupQuery, SettingGroupModel>
    {
        private readonly ISettingGroupService settingGroupService;

        public GetSettingGroupHandler(
            ILogger<GetSettingGroupHandler> logger,
            ISettingGroupService settingGroupService
        ) : base(logger)
        {
            this.settingGroupService = settingGroupService;
        }

        protected async override Task<Result<SettingGroupModel>> Act(GetSettingGroupQuery request, CancellationToken cancellationToken)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(request.Id);
            return await settingGroupService.GetById(request.Id, cancellationToken);
        }
    }
}
