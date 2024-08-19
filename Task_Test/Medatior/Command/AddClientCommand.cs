using Mediator;
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
      int ClientId,
      string ClientName,
      string District,
      string Address,
      string Nationality,
      string Job,
      string Residence,
      string Email,
      string SalesMan,
      string CustomerClassification,
      string Description, string Mobile,
      string TelephoneOne, string TelephoneTwo,
      string WhatsApp) : IRequest<ResponseResult>;

    public class AddCallCommand:IRequest<ResponseResult>
    {
        public int ClientId { get; set; }

        public string? Description { get; set; }
      
        public string CallAdress { get; set; }
 
        public string Employee { get; set; }
      
        public string project { get; set; }
 
        public string? CallHistory { get; set; }
        public string TypeOfCall { get; set; }
    }
    public class ResponseResult
    {
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}