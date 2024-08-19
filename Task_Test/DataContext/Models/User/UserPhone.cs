using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Task_Test.DataContext.Models.User
{
    public class UserPhone
    {
        [Key]
        public int UserPhoneId { get; set; }
        [ForeignKey("ClientId")]
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public string Mobile { get; set; }
        public string? TelephoneOne { get; set; }
        public string? TelephoneTwo { get; set; }
        public string? WhatsApp { get; set;}

        [MaxLength(4)]
        public string? CountryCode { get; set; } // remove
    }
}
