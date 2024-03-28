namespace MinCQRS.DAL.Repos
{
    using MinCQRS.DAL.Data;
    using MinCQRS.DAL.Entities;
    using MinCQRS.DAL.Repos.Interfaces;

    public sealed class SettingGroupsRepo : BaseRepository<SettingGroupEntity>, ISettingGroupsRepo
    {
        public SettingGroupsRepo(BaseDBContext context) : base(context)
        {
        }
    }
}
