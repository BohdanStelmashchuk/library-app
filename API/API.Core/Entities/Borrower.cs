namespace API.Core.Entities
{
    public class Borrower
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<Loan> Loans { get; set; }
    }
}
