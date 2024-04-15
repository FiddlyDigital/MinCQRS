namespace MinCQRS.API.Endpoints.SettingGroups
{
    using LanguageExt.Common;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using MinCQRS.API.Constants;
    using MinCQRS.API.Endpoints.Base;
    using MinCQRS.Application.Handlers.Base.GenericQueries;
    using MinCQRS.Application.Handlers.SettingGroups;
    using MinCQRS.Domain.Models;
    using MinCQRS.Domain.Models.Base;

    public sealed class GetSettingGroupListEndpoint : GetListEndpoint<GetSettingGroupListQuery, SettingGroupModel>, IEndpoint
    {
        public GetSettingGroupListEndpoint() : base(Resources.Routes.SettingGroups) { }
    }
}
