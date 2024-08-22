using Mediator;
namespace Task_Test.Medatior.Command
{
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
}