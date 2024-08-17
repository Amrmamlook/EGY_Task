using Mediator;
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

            group.MapPost( "AddClient",AddClient).AddEndpointFilter<ValidatorFilter<AddClientCommand>>()
                .RequireAuthorization("Admin");

            group.MapGet("Clients",GetClients);
        }
        public static async Task<IResult> AddClient( [FromBody]AddClientCommand command , [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(command);
            return Results.Ok(result);
        }
        static async Task<IResult> GetClients(
           [FromServices] IMediator mediator,
            int pageNumber = 1,
            int pageSize = 5)
        {
            var result = await mediator.Send(new GetClientsQuery(pageNumber,pageSize));
           
            return Results.Ok(result);
        }
    }
}
