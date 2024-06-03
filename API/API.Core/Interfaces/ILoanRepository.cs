using API.Core.Entities;

namespace API.Core.Interfaces
{
    public interface ILoanRepository
    {
        Task AddAsync(Loan loan);
    }
}
