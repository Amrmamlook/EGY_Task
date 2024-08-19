using Mediator;
using Microsoft.AspNetCore.Mvc;
namespace Task_Test.Medatior.Command
{
    public record AddClientCommand(
        string ClientName, 
        string District,
        string Address, 
        string Nationality, 
        string Job, 
        string Residence,
        string Email ,
        string SalesMan,
        string CustomerClassification,
        string Description ,string Mobile ,
        string TelephoneOne, string TelephoneTwo,
        string WhatsApp):IRequest<ResponseResult>;

    public record UdateClientCommand(
      [FromQuery] int ClientId,
      [FromForm] string ClientName,
      [FromForm]  string District,
      [FromForm] string Address,
      [FromForm] string Nationality,
      [FromForm] string Job,
      [FromForm] string Residence,
      [FromForm] string Email,
      [FromForm] string SalesMan,
      [FromForm] string CustomerClassification,
      [FromForm] string Description, string Mobile,
      [FromForm] string TelephoneOne, string TelephoneTwo,
      [FromForm] string WhatsApp) : IRequest<ResponseResult>;
    public class ResponseResult
    {
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}