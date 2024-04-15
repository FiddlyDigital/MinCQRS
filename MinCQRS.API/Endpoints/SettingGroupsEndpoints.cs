using MinCQRS.API.Constants;
using MinCQRS.API.Endpoints.Base;
using MinCQRS.Application.Handlers.SettingGroups;
using MinCQRS.Domain.Models;

namespace MinCQRS.API.Endpoints
{
    public sealed class GetSettingGroupListEndpoint : GetListEndpoint<GetSettingGroupListQuery, SettingGroupModel>, IEndpoint
    {
        public GetSettingGroupListEndpoint() : base(Resources.Routes.SettingGroups) { }
    }

    public sealed class GetSettingGroupByIdEndpoint : GetByIdEndpoint<GetSettingGroupByIdQuery, SettingGroupModel>, IEndpoint
    {
        public GetSettingGroupByIdEndpoint() : base(Resources.Routes.SettingGroups) { }
    }
}
