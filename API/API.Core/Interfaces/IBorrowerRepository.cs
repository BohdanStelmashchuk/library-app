using API.Core.Models;

namespace API.Core.Interfaces
{
    public interface IBorrowerRepository
    {
        Task<List<BorrowersByBookId>> GetBorrowersByBookIdAsync (int bookId);
    }
}
