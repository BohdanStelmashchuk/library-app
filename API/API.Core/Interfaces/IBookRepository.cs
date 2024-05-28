using API.Core.Entities;

namespace API.Core.Interfaces
{
    public interface IBookRepository
    {
        Task<Book> GetByIdAsync(int id);
        Task<IEnumerable<Book>> GetAllAsync();
        Task AddAsync(Book book);
        Task UpdateAsync(int id, Book book);
        Task DeleteAsync(int id);
    }
}
