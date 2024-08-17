using System.ComponentModel.DataAnnotations;

namespace Task_Test.Options.Request
{
    public class AccountRequest // Use Fluent Validation
    {
        [Required]
        [EmailAddress]
        [MaxLength(200)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(20)]
        public string Password { get; set; }

        [MaxLength(100)]
        [RegularExpression(@"^[a-zA-Z]{3,20}[0-9]{0,4}$", ErrorMessage = "Invalid UserName")]
        public string UserName { get; set; }
    }
}
