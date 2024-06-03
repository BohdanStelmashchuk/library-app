namespace API.Core.Models
{
    public class FilteredBooks
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public string Authors { get; set; }
        public bool? IsLoaned { get; set; }
    }
}
