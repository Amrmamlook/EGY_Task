using Mediator;
using Microsoft.AspNetCore.Mvc;
using Task_Test.Medatior.Command;
using Task_Test.Medatior.Query;

namespace Task_Test.Endpoints.CallsEndpoints
{
    public static class CallEndPoint
    {
        public static void MapCallsEndPoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/Calls").WithTags(Tags.Calls);
            group.MapPost("addCall", AddCall);

            group.MapGet("", GetCallsOfClient);
        }
        public static async Task<IResult> GetCallsOfClient(
          [FromServices] IMediator mediator,
          [FromQuery] int ClientId,
          [FromQuery] int pageNumber = 1,
          [FromQuery] int pageSize = 5)
        {
            var result = await mediator.Send(new GetCallsOfClientQuery(ClientId, pageNumber, pageSize));
            return Results.Ok(result);
        }

        public static async Task<IResult> AddCall(int clientId, string? description, string callAdress, string employee, string project, string? callHistory, string typeOfCall, [FromServices] IMediator mediator)
        {
            var command = new AddCallCommand
            {
                ClientId = clientId,
                Description = description,
                CallAdress = callAdress,
                Employee = employee,
                project = project,
                CallHistory = callHistory,
                TypeOfCall = typeOfCall
            };
            var result = await mediator.Send(command);
            return Results.Ok(result);
        }
    }
}
