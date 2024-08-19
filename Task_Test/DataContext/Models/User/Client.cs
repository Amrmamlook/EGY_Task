using System.ComponentModel.DataAnnotations.Schema;

namespace Task_Test.DataContext.Models.User
{
    public class Client:AppUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string Natinality { get; set; }
        public string Job { get; set; }
        public string Residence { get; set; }
        public DateOnly AccountCreationDate { get; set; }
        public int AddedByUserId { get; set; }

        public int? ModifiedBy { get; set; }
        public DateOnly? DateModified { get; set; }

        public string? SalesMan { get; set; }
        public string? Description { get; set; }
        public string? CustomerClassifications { get; set; }
        public string? CustomerSource { get; set; }

        public ICollection<UserPhone>? Phones { get; set; }

        [ForeignKey("AddedByUserId")]
        public AppUser AddedByUser { get; set; }

        [ForeignKey("ModifiedBy")]
        public AppUser ModifiedByUser { get; set; }
    }
}
