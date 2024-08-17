using System.ComponentModel;
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
        [JsonPropertyName("أضيف بواسطة")]
        public string AddedBy { get; set; }
        [JsonPropertyName("تاريخ الادخال")]
        public DateOnly AccountCreationDate { get; set; }
        [JsonPropertyName("تم التعديل بواسطة")]
        public string? ModifiedBy { get; set; }
        [JsonPropertyName("تاريخ التعديل")]
        public DateOnly? DateModified { get; set; }
    }
}
