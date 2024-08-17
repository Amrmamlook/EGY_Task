using Mediator;
using Microsoft.AspNetCore.Mvc;

using System.Text.Json.Serialization;

namespace Task_Test.Medatior.Command
{
    public class AddClientCommand:IRequest<ResponseResult>
    {
        [FromBody]
        [JsonPropertyName("اسم_العميل")]
        public string ClientName { get; set; }

        [FromBody]
        [JsonPropertyName("الحي")]
        public string District { get; set; } 

        [FromBody]
        [JsonPropertyName("العنوان")]
        public string Address { get; set; } 

        [FromBody]
        [JsonPropertyName("الجنسية")]
        public string Nationality { get; set; }

        [FromBody]
        [JsonPropertyName("الوظيفة")]
        public string Job { get; set; }

        [FromBody]
        [JsonPropertyName("الاقامة")]
        public string Residence { get; set; }
        [FromBody]
        [JsonPropertyName("الايميل")]
        public string Email { get; set; }

        [FromBody]
        [JsonPropertyName("الارقام")]
        public List<UserPhoneDto> Phones { get; set; } = [];
    }
    public class UserPhoneDto
    {
        [JsonPropertyName("موبايل")]
        public string Mobile { get; set; }

        [JsonPropertyName("تليفون_1")]
        public string TelephoneOne { get; set; }

        [JsonPropertyName("تليفون_2")]
        public string TelephoneTwo { get; set; }

        [JsonPropertyName("واتساب")]
        public string WhatsApp { get; set; }
    }

    public class ResponseResult
    {
        public string message { get; set; }
        public bool Success { get; set; }
    }

}
