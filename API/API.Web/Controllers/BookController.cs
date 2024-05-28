using API.Core.Interfaces;
using API.Web.DTOs.BookDtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookService.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _bookService.GetByIdAsync(id);

            var bookDto = BookDto.ToDto(book);
            return Ok(bookDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateBookDto bookDto)
        {
            var book = CreateBookDto.ToEntity(bookDto);

            await _bookService.AddAsync(book);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, UpdateBookDto updateBookDto)
        {
            var book = UpdateBookDto.ToEntity(updateBookDto);
            await _bookService.UpdateAsync(id, book);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _bookService.DeleteAsync(id);
                return Ok();
            }

            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
