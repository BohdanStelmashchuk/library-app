using API.Core.Entities;

namespace API.Web.DTOs.LoanDtos
{
    public class CreateLoanDto
    {
        public int BookId { get; set; }
        public int BorrowerId { get; set; }
        public DateTime LoanDate { get; set; } = DateTime.UtcNow;
        public DateTime? ReturnDate { get; set; }
    }

    public static class CreateLoanMapper
    {
        public static Loan ToEntity(this CreateLoanDto createLoanDto)
        {
            return new Loan
            {
                BookId = createLoanDto.BookId,
                BorrowerId = createLoanDto.BorrowerId,
                ReturnDate = createLoanDto.ReturnDate ?? default,
                LoanDate = createLoanDto.LoanDate
            };
        }
    }
}
