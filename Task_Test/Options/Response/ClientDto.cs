using System.Text.Json.Serialization;

namespace Task_Test.Options.Response
{
    public class ClientDto
    {
        [JsonPropertyName("اسم_العميل")]
        public string Name { get; set; }
        [JsonPropertyName("الوظيفة")]
        public string Job { get; set; }
        [JsonPropertyName("الاقامة")]
        public string Residence { get; set; }

        [JsonPropertyName("أضيف_بواسطة")]
        public string AddedBy { get; set; }

        [JsonPropertyName("تاريخ_الادخال")]
        public string  AccountCreationDate { get; set; }

        [JsonPropertyName("تم_التعديل_بواسطة")]
        public string? ModifiedBy { get; set; }
        [JsonPropertyName("تاريخ_التعديل")]
        public string? DateModified { get; set; }

        [JsonPropertyName("رجل_المبيعات")]
        public string? SalesMan { get; set; }
       
        [JsonPropertyName("التصنيف")]
        public string? CustomerClassification { get; set; }
      
        [JsonPropertyName("التوصيف")]
        public string? Description { get; set; }
    }
}
