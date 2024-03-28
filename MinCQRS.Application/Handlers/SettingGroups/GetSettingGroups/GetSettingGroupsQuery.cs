namespace MinCQRS.Application.Handlers.SettingsGroups.GetSettingGroups
{
    using MinCQRS.Application.Handlers.Base.Interfaces;
    using MinCQRS.Domain.Models;
    using LanguageExt.Common;

    public sealed class GetSettingGroupsQuery : IQuery<Result<ICollection<SettingGroupModel>>>
    {
        public GetSettingGroupsQuery()
        {
        }
    }
}
