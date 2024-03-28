namespace MinCQRS.BLL.Services
{
    using Microsoft.Extensions.Logging;
    using MinCQRS.BLL.Services.Base;
    using MinCQRS.BLL.Services.Interfaces;
    using MinCQRS.DAL.Entities;
    using MinCQRS.DAL.Repos.Interfaces;
    using MinCQRS.Domain.Models;

    public sealed class SettingGroupService : CRUDService<SettingGroupService, SettingGroupModel, SettingGroupEntity>, ISettingGroupService
    {
        public SettingGroupService(ILogger<SettingGroupService> logger, ISettingGroupsRepo repository) : base(logger, repository)
        {

        }
    }
}
