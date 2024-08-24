using Mediator;
using Microsoft.AspNetCore.Mvc;
namespace Task_Test.Medatior.Command
{
    public record AddClientCommand(
        string Name, 
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

    public record UpdateClientCommand(
        string Name,
        string District,
        string Address,
        string Nationality,
        string Job,
        string Residence,
        string Email,
        string SalesMan,
        string CustomerClassification,
        string Description, 
        string Mobile,
        string TelephoneOne, 
        string TelephoneTwo,
        string WhatsApp) : IRequest<ResponseResult>;

    public class ResponseResult
    {
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}