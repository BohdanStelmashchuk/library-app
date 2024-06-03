using API.Core.Entities;

namespace API.Core.Interfaces
{
    public interface ILoanService
    {
        Task AddAsync(Loan loan);
    }
}
