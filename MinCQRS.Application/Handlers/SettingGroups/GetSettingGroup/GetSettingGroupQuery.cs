namespace MinCQRS.Application.Handlers.SettingGroups.GetSettingGroup
{
    using LanguageExt.Common;
    using MinCQRS.Application.Handlers.Base.Interfaces;
    using MinCQRS.Domain.Models;

    public sealed class GetSettingGroupQuery : IQuery<Result<SettingGroupModel>>
    {
        public GetSettingGroupQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
