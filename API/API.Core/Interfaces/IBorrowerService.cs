using API.Core.Models;

namespace API.Core.Interfaces
{
    public interface IBorrowerService
    {
        Task<List<BorrowersByBookId>> GetBorrowersByBookIdAsync (int bookId);
    }
}
