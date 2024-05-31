using API.Core.Models;

namespace API.Web.DTOs.BookDtos
{
    public class BookFilterDto
    {
        public string Title { get; set; }
        public string[] Authors { get; set; }
    }

    public static class BookFilterMapper
    {
        public static BookFilter ToFilterModel (this BookFilterDto bookFilterDto)
        {
            return new BookFilter
            {
                Title = bookFilterDto.Title,
                Authors = bookFilterDto.Authors,
            };
        }
    }
}
