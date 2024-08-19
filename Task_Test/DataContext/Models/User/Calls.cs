namespace Task_Test.DataContext.Models.User
{
    public class Calls
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public string? Description { get; set; }
        public string CallAdress { get; set; }
        public string Employee { get; set; }
        public string project { get; set; }
        public DateOnly? CallHistory { get; set; }
        public string TypeOfCall { get; set; }
    }
}
