using API.Core.Entities;
using API.Core.Models;

namespace API.Core.Interfaces
{
    public interface IBookRepository
    {
        Task<Book> GetByIdAsync(int id);
        Task<IEnumerable<Book>> GetAllAsync();
        Task<List<FilteredBooks>> GetFilteredAsync(BookFilter bookFilter);
        Task AddAsync(Book book);
        Task UpdateAsync(int id, Book book);
        Task DeleteByIdAsync(int id);
    }
}
