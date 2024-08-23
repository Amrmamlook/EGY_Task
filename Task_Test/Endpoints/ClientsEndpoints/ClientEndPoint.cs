﻿using Mediator;
using Microsoft.AspNetCore.Mvc;
using Planta_BackEnd.Filters;
using Task_Test.Medatior.Command;
using Task_Test.Medatior.Query;

namespace Task_Test.Endpoints.ClientsEndpoints
{
    public static class ClientEndPoint
    {
        public static void MapClientEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/client").WithTags(Tags.Client);

            group.MapPost("AddClient", AddClient)
                .AddEndpointFilter<ValidatorFilter<AddClientCommand>>().DisableAntiforgery();
                //.RequireAuthorization("Admin");

            group.MapGet("Clients",GetClients);

            group.MapGet("{clientId}", GetClientById);

            group.MapPut("/{clientId}/update", UpdateClient);
        }
        public static async Task<IResult> AddClient(
            [FromBody]AddClientCommand command , 
            [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(command);
            return Results.Ok(result);
        }

        public static async Task<IResult> GetClientById([FromRoute]int clientId,[FromServices]IMediator mediator)
        {
            var result = await mediator.Send(new GetClientByIdQuery(clientId));
            return result.Match(
                _=> Results.NotFound(),
                _=> Results.Ok(result.AsT1)
                );
        }

        static async Task<IResult> GetClients(
        [FromServices] IMediator mediator,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 5)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return Results.BadRequest("Page number and page size must be positive integers.");
            }
            var result = await mediator.Send(new GetClientsQuery(pageNumber, pageSize));

            return Results.Ok(result);
        }

        public static async Task<IResult> UpdateClient(
            [FromRoute] int clientId,
             UdateClientCommand command,
            [FromServices] IMediator mediator)
        {
            var updatedCommand = command with { ClientId = clientId };

            var result = await mediator.Send(updatedCommand);

            return Results.Ok(result);
        }
    }
}