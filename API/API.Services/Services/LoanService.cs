using API.Core.Entities;
using API.Core.Interfaces;

namespace API.Services.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepository;

        public LoanService(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task AddAsync(Loan loan)
        {
            await _loanRepository.AddAsync(loan);
        }
    }
}
