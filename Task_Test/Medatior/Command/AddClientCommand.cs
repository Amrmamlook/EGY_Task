using Mediator;
using Microsoft.AspNetCore.Mvc;

using System.Text.Json.Serialization;

namespace Task_Test.Medatior.Command
{
    public class AddClientCommand:IRequest<ResponseResult>
    {
        [FromBody]
       
        public string ClientName { get; set; }

        [FromBody]
      
        public string District { get; set; } 

        [FromBody]
       
        public string Address { get; set; } 

        [FromBody]
       
        public string Nationality { get; set; }

        [FromBody]
      
        public string Job { get; set; }

        [FromBody]
      
        public string Residence { get; set; }
        [FromBody]
      
        public string Email { get; set; }

        [FromBody]
     
        public string? SalesMan { get; set; }
        [FromBody]
    
        public string? CustomerClassification { get; set; }
        [FromBody]
       
        public string Description { get; set; }
        [FromBody]
        public string Mobile { get; set; }

        [FromBody]
        public string TelephoneOne { get; set; }

        [FromBody]
        public string TelephoneTwo { get; set; }

        [FromBody]
        public string WhatsApp { get; set; }

        //[FromBody]
        // [JsonPropertyName("الارقام")]
        //public List<UserPhoneDto> Phones { get; set; } = [];
    }
    public class UserPhoneDto
    {
       // [JsonPropertyName("موبايل")]
        public string Mobile { get; set; }

       // [JsonPropertyName("تليفون_1")]
        public string TelephoneOne { get; set; }

        //[JsonPropertyName("تليفون_2")]
        public string TelephoneTwo { get; set; }

        //[JsonPropertyName("واتساب")]
        public string WhatsApp { get; set; }
    }

    public class ResponseResult
    {
        public string Message { get; set; }
        public bool Success { get; set; }
    }

}
