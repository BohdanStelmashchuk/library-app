using API.Core.Interfaces;
using API.Core.Models;

namespace API.Services.Services
{
    public class BorrowerService : IBorrowerService
    {
        private readonly IBorrowerRepository _borrowerRepository;

        public BorrowerService (IBorrowerRepository borrowerRepository)
        {
            _borrowerRepository = borrowerRepository;
        }

        public async Task<List<BorrowersByBookId>> GetBorrowersByBookIdAsync (int bookId)
        {
            return await _borrowerRepository.GetBorrowersByBookIdAsync(bookId);
        }
    }
}
