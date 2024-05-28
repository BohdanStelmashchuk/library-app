using API.Core.Entities;

namespace API.Web.DTOs.BookDtos
{
    public class UpdateBookDto
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public int PublisherId { get; set; }
    }

    public static class UpdateBookMapper
    {
        public static Book ToEntity(this UpdateBookDto updateBookDto)
        {
            return new Book
            {
                Title = updateBookDto.Title,
                ISBN = updateBookDto.ISBN,
                Price = updateBookDto.Price,
                PublisherId = updateBookDto.PublisherId
            };
        }
    }
}
