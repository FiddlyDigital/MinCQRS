using MinCQRS.DAL.Data;
using MinCQRS.DAL.Data.Interfaces;
using MinCQRS.DAL.Entities;

namespace MinCQRS.DAL.Repos
{
    public interface ISettingGroupsRepo : IBaseRepository<SettingGroupEntity> { }

    public sealed class SettingGroupsRepo : BaseRepository<SettingGroupEntity>, ISettingGroupsRepo
    {
        public SettingGroupsRepo(BaseDBContext context) : base(context)
        {

        }
    }
}
