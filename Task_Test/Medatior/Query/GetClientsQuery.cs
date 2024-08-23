using Mediator;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OneOf;
using Planta_BackEnd.Mediator;
using Task_Test.Options.Response;

namespace Task_Test.Medatior.Query
{
    public record GetClientsQuery([FromQuery]int PageNumber,[FromQuery] int PageSize) :IRequest<PageList<ClientDto>>;


    public record GetCallsOfClientQuery([FromQuery] int ClientId, [FromQuery] int PageNumber, [FromQuery] int PageSize) :IRequest<PageList<CallDto>>;
     
    public record GetClientByIdQuery([FromRoute] int ClientId):IRequest<OneOf<OneOf.Types.NotFound,ClientInfoDto>>;
    public class ClientInfoDto
    {
        public string Name { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string Nationality { get; set; }
        public string Job { get; set; }
        public string Residence { get; set; }
        public string Email { get; set; }
        public string? SalesMan { get; set; }
        public string? Description { get; set; }
        public string? CustomerClassifications { get; set; }
        public string? CustomerSource { get; set; }

        public string? Mobile { get; set; }
        public string? TelephoneOne { get; set; }
        public string? TelephoneTwo { get; set; }
        public string? WhatsApp { get; set; }
    }
    

}
