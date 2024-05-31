using API.Core.Interfaces;
using API.Core.Models;
using API.DataAccess.Data;

namespace API.DataAccess.Repositories
{
    public class BorrowerRepository : IBorrowerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BorrowerRepository (ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<BorrowersByBookId>> GetBorrowersByBookIdAsync (int bookId)
        {
            return await _dbContext.GetBorrowersByBookIdAsync(bookId);
        }
    }
}
