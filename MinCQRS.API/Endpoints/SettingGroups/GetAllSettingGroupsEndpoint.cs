namespace MinCQRS.API.Endpoints.SettingGroups
{
    using LanguageExt.Common;
    using MediatR;
    using MinCQRS.API.Constants;
    using MinCQRS.Application.Handlers.SettingsGroups.GetSettingGroups;
    using MinCQRS.Domain.Models;

    public class GetAllSettingGroupsEndpoint : IEndpoint
    {
        private readonly string EndpointRoute = Routes.Endpoints.SettingGroups;

        private async Task<IResult> GetAllAsync(ISender mediator)
        {
            Result<ICollection<SettingGroupModel>> result = await mediator.Send(new GetSettingGroupsQuery());
            return result.Match(
                Succ: val => Results.Ok(val),
                Fail: exception => Results.Problem(exception.Message));
        }

        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet(EndpointRoute, GetAllAsync)
                .WithName("GetSettingGroups")
                .WithOpenApi();
        }
    }
}
