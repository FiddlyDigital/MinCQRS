namespace MinCQRS.API.Endpoints.SettingGroups
{
    using LanguageExt.Common;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using MinCQRS.API.Constants;
    using MinCQRS.Application.Handlers.SettingsGroups.GetSettingGroups;
    using MinCQRS.Domain.Models;

    // Candidate for Base extraction
    public class GetListSettingGroupsEndpoint : IEndpoint
    {
        private int maxPage = 50;
        private int maxPageSize = 50;
        private readonly string EndpointRoute = Routes.Endpoints.SettingGroups;

        private async Task<IResult> GetListAsync(ISender mediator, int page = 1, int pageSize = 25)
        {
            if (page < 1)
            {
                return Results.BadRequest("A");
            }

            if (page > maxPage)
            {
                return Results.BadRequest("B");
            } 

            if (pageSize < 1)
            {
                return Results.BadRequest("C");
            }

            if (pageSize > maxPageSize)
            {
                return Results.BadRequest("D");
            }

            Result<ICollection<SettingGroupModel>> result = await mediator.Send(
                new GetSettingGroupListQuery((page -1), pageSize)
            );
            
            return result.Match(
                Succ: val => Results.Ok(val),
                Fail: exception => Results.Problem(exception.Message));
        }

        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet(EndpointRoute, (
                    ISender mediator,
                    [FromQuery(Name = "page")] int page,
                    [FromQuery(Name = "pageSize")] int pageSize
                ) => GetListAsync(mediator, page, pageSize))
                .WithName("GetSettingGroups")
                .WithOpenApi()
            .Produces<ICollection<SettingGroupModel>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError);
        }
    }
}
