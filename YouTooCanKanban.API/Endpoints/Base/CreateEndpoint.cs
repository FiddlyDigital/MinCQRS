﻿using LanguageExt.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using YouTooCanKanban;
using YouTooCanKanban.API;
using YouTooCanKanban.API.Constants;
using YouTooCanKanban.API.Endpoints;
using YouTooCanKanban.API.Endpoints.Base;
using YouTooCanKanban.Application.Handlers.Base.GenericCommands;
using YouTooCanKanban.Domain.Models;
using YouTooCanKanban.Domain.Models.Base;

namespace YouTooCanKanban.API.Endpoints.Base
{
    public abstract class CreateEndpoint<TCommand, TResponse>
        where TCommand : CreateCommand<TResponse>, new()
        where TResponse : BaseModel
    {
        private readonly string EndpointRoute;

        public CreateEndpoint(string endpoint)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(endpoint, nameof(endpoint));
            EndpointRoute = endpoint;
        }

        private static async Task<IResult> CreateAsync(ISender mediator, TResponse model)
        {
            ArgumentNullException.ThrowIfNull(model, nameof(model));

            TCommand createCommand = new TCommand() 
            {
                Model = model
            };            

            var result = await mediator.Send(createCommand);

            return result.Match(
                Succ: val => Results.Ok(val),
                Fail: exception => Results.Problem(exception.Message));
        }

        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost(EndpointRoute, (
                    ISender mediator,
                    [FromBody()] TResponse model
                ) => CreateAsync(mediator, model))
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Creates a new" + EndpointRoute,
                    Description = "Will create a new " + EndpointRoute + ".",
                    Tags = new[]
                    {
                        new OpenApiTag()
                        {
                            Name = EndpointRoute,
                        }
                    }
                });
        }
    }
}
