using API.Core.Entities;

namespace API.Web.DTOs.BookDtos
{
    public class CreateBookDto
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public int PublisherId { get; set; }
    }

    public static class CreateBookMapper
    {
        public static Book ToEntity (this CreateBookDto createBookDto)
        {
            return new Book
            {
                Title = createBookDto.Title,
                ISBN = createBookDto.ISBN,
                Price = createBookDto.Price,
                PublisherId = createBookDto.PublisherId
            };
        }
    }
}
