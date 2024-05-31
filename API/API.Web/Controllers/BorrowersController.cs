using API.Core.Interfaces;
using API.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BorrowersController : ControllerBase
    {
        private readonly IBorrowerService _borrowerService;

        public BorrowersController (IBorrowerService borrowerService)
        {
            _borrowerService = borrowerService;
        }

        [HttpGet("{bookId}")]
        public async Task<List<BorrowersByBookId>> GetBorrowersByBookIdAsync (int bookId)
        {
            return await _borrowerService.GetBorrowersByBookIdAsync(bookId);
        }
    }
}
