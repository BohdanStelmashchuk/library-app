using API.Core.Entities;
using API.Core.Interfaces;
using API.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace API.DataAccess.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LoanRepository (ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Loan loan)
        {
            var loanExists = await _dbContext.Loans.FirstOrDefaultAsync(x => x.BookId == loan.BookId);
            if (loanExists == null)
            {
                await _dbContext.Loans.AddAsync(loan);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Loan already exists");
            }
        }
    }
}
