using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Task_Test.DataContext.Models.User
{
    public class AppUser : IdentityUser<int>
    {
       
    }
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
    public class Client:AppUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string District { get; set; } // الحي
        public string Address { get; set; } // العنوان
        public string Natinality { get; set; } // الجنسية
        public string Job { get; set; } // الوظيفة
        public string Residence { get; set; }  // الاقامة
        public DateOnly AccountCreationDate { get; set; }
        public int AddedByUserId { get; set; }

        public int? ModifiedBY { get; set; }
        public DateOnly? DateModified { get; set; }

        public ICollection<UserPhone>? Phones { get; set; }
    }
}
