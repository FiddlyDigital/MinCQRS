namespace MinCQRS.Application.Handlers.SettingsGroups.GetSettingGroups
{
    using MinCQRS.Domain.Models;
    using MinCQRS.Application.Handlers.Base.GenericQueries;

    public sealed class GetSettingGroupListQuery : GetListQuery<SettingGroupModel>
    {
        public GetSettingGroupListQuery(int pageIndex, int pageSize) : base(pageIndex, pageSize) { } 
    }
}
