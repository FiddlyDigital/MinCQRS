namespace MinCQRS.Application.Handlers.SettingsGroups.GetSettingGroups
{
    using LanguageExt.Common;
    using Microsoft.Extensions.Logging;
    using MinCQRS.Application.Handlers.Base;
    using MinCQRS.BLL.Services.Interfaces;
    using MinCQRS.Domain.Models;

    public sealed class GetSettingGroupHandler : BaseQueryHandler<GetSettingGroupHandler, GetSettingGroupsQuery, ICollection<SettingGroupModel>>
    {
        private readonly ISettingGroupService settingGroupService;

        public GetSettingGroupHandler(
            ILogger<GetSettingGroupHandler> logger,
            ISettingGroupService settingGroupService
        ) : base(logger)
        {
            this.settingGroupService = settingGroupService;
        }

        protected async override Task<Result<ICollection<SettingGroupModel>>> Act(GetSettingGroupsQuery request, CancellationToken cancellationToken)
        {
            return await settingGroupService.GetAll();
        }
    }
}
