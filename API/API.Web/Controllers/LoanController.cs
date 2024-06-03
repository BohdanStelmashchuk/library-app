using API.Core.Interfaces;
using API.Web.DTOs.LoanDtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoanController (ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpPost]
        public async Task<IActionResult> AddLoanAsync(CreateLoanDto createLoanDto)
        {
            var loan = createLoanDto.ToEntity();

            await _loanService.AddAsync(loan);
            return Ok();
        }
    }
}
