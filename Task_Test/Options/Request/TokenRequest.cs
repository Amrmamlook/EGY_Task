using System.ComponentModel.DataAnnotations;

namespace Task_Test.Options.Request
{
    public class TokenRequest
    {
        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }

        [MinLength(8)]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
