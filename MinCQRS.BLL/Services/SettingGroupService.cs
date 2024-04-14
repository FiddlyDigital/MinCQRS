using Microsoft.Extensions.Logging;
using MinCQRS.BLL.Services.Base;
using MinCQRS.BLL.Services.Base.Interfaces;
using MinCQRS.DAL.Entities;
using MinCQRS.DAL.Repos;
using MinCQRS.Domain.Models;

namespace MinCQRS.BLL.Services
{
    public interface ISettingGroupService : ICrudService<SettingGroupService, SettingGroupModel>
    {

    }

    public sealed class SettingGroupService : CRUDService<SettingGroupService, SettingGroupModel, SettingGroupEntity>, ISettingGroupService
    {

        public SettingGroupService(ILogger<SettingGroupService> logger, ISettingGroupsRepo repository) : base(logger, repository)
        {

        }
    }
}
