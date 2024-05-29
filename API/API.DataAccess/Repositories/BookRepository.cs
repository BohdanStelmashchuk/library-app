using API.Core.Entities;
using API.Core.Interfaces;
using API.Core.Models;
using API.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace API.DataAccess.Repositories;

public class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext _dbContext;

    public BookRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await _dbContext.Books.ToListAsync();
    }

    public async Task<Book> GetByIdAsync(int id)
    {
        var book = await _dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
        return book == null ? throw new KeyNotFoundException() : book;
    }

    public async Task<List<FilteredBooks>> GetFilteredAsync(BookFilter bookFilter)
    {
        return await _dbContext.GetFilteredBooksAsync(bookFilter);
    }

    public async Task AddAsync(Book book)
    {
        await _dbContext.Books.AddAsync(book);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, Book book)
    {
        var bookToUpdate = await _dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
        
        if (bookToUpdate == null)
        {
            throw new KeyNotFoundException();
        }

        bookToUpdate.Title = book.Title;
        bookToUpdate.ISBN = book.ISBN;
        bookToUpdate.Price = book.Price;
        bookToUpdate.PublisherId = book.PublisherId;

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var book = await _dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
        if (book != null)
        {
            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
        }
        else
        {
            throw new KeyNotFoundException();
        }

    }
}