﻿using API.Core.Entities;
using API.Core.Interfaces;
using API.Core.Models;

namespace API.Services.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService (IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _bookRepository.GetAllAsync();
        }

        public async Task<Book> GetByIdAsync (int id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }

        public async Task<List<FilteredBooks>> GetFilteredAsync (BookFilter bookFilter)
        {
            return await _bookRepository.GetFilteredAsync(bookFilter);
        }

        public async Task AddAsync (Book book)
        {
            await _bookRepository.AddAsync(book);
        }

        public async Task UpdateAsync (int id, Book book)
        {
            await _bookRepository.UpdateAsync(id, book);
        }

        public async Task DeleteByIdAsync (int id)
        {
            await _bookRepository.DeleteByIdAsync(id);
        }
    }
}
