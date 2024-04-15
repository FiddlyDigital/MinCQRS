using LanguageExt.Common;
using MediatR;
using MinCQRS.API.Constants;
using MinCQRS.API.Endpoints.Base;
using MinCQRS.Application.Handlers.SettingGroups;
using MinCQRS.Domain.Models;

namespace MinCQRS.API.Endpoints.SettingGroups
{
    public sealed class GetSettingGroupByIdEndpoint : IEndpoint
    {
        private readonly string EndpointRoute = Resources.Routes.SettingGroups;

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
            Result<SettingGroupModel> result = await mediator.Send(new GetSettingGroupByIdQuery(id));
            return result.Match(
                Succ: val => Results.Ok(val),
                Fail: exception => Results.Problem(exception.Message));
        }
    }
}
