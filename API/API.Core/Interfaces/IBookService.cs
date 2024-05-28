﻿using API.Core.Entities;

namespace API.Core.Interfaces
{
    public interface IBookService
    {
        Task<Book> GetByIdAsync(int id);
        Task<IEnumerable<Book>> GetAllAsync();
        Task AddAsync(Book book);
        Task UpdateAsync(int id, Book book);
        Task DeleteByIdAsync(int id);
    }
}
