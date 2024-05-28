using API.Core.Entities;

namespace API.Web.DTOs.BookDtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public int PublisherId { get; set; }
    }

    public static class BookMapper
    {
        public static BookDto ToDto(this Book book)
        {
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                ISBN = book.ISBN,
                Price = book.Price,
                PublisherId = book.PublisherId
            };
        }
    }
}
