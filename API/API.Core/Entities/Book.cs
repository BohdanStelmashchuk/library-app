using System.ComponentModel.DataAnnotations.Schema;

namespace API.Core.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("Publisher")]
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public List<BookAuthor> BookAuthors { get; set; }
    }
}
