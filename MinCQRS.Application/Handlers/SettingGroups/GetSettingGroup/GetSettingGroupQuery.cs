namespace MinCQRS.Application.Handlers.SettingGroups.GetSettingGroup
{
    using MinCQRS.Application.Handlers.Base.GenericQueries;
    using MinCQRS.Domain.Models;

    public sealed class GetSettingGroupQuery : GetByIdQuery<SettingGroupModel>
    {
        public GetSettingGroupQuery(int id) : base(id) { }
    }
}
