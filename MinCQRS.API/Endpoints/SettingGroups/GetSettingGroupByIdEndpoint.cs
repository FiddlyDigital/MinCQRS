﻿namespace MinCQRS.API.Endpoints.SettingGroups
{
    using LanguageExt.Common;
    using MediatR;
    using MinCQRS.API.Constants;
    using MinCQRS.Application.Handlers.SettingGroups.GetSettingGroup;
    using MinCQRS.Domain.Models;

    public class GetSettingGroupByIdEndpoint : IEndpoint
    {
        private readonly string EndpointRoute = Routes.Endpoints.SettingGroups;

        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app
                .MapGet(EndpointRoute + "/{id:int}", GetByIdAsync)
                .WithName("GetSettingGroupById")
                .WithOpenApi(
                    operation => new(operation)
                    {
                        Summary = "Get a specific SettingGroup",
                        Description = "Will return the requested SettingGroup if available, otherwise a 404"
                    }
                )
                .Produces<SettingGroupModel>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status404NotFound)
                .Produces(StatusCodes.Status500InternalServerError);
        }

        private static async Task<IResult> GetByIdAsync(ISender mediator, int id)
        {
            if (id <= 0)
            {
                return Results.BadRequest();
            }

            Result<SettingGroupModel> result = await mediator.Send(new GetSettingGroupQuery(id));
            return result.Match(
                Succ: val => Results.Ok(val),
                Fail: exception => Results.Problem(exception.Message));
        }
    }
}
