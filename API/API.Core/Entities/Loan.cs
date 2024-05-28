using System.ComponentModel.DataAnnotations.Schema;

namespace API.Core.Entities
{
    public class Loan
    {
        public int Id { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book Book { get; set; }
        [ForeignKey("Borrower")]
        public int BorrowerId { get; set; }
        public Borrower Borrower { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
