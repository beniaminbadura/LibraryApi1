using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApi.Context;
using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Repository
{
    public class BooksRepository : IBooksRepository
    {
        private LibraryDbContext libraryDbContext;
        public BooksRepository(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await libraryDbContext.Books.Include(b=>b.Author).AsNoTracking().ToListAsync();
        }

        public async Task<Book> Get(string id)
        {
            return await libraryDbContext.Books.Include(b => b.Author).AsNoTracking().FirstOrDefaultAsync(b => b.Id.Equals(id));
        }

        public async Task Add(Book book)
        {
            await libraryDbContext.Books.AddAsync(book);
            await libraryDbContext.SaveChangesAsync();
        }

        public async Task Update(string id, Book book)
        {
            var bookToUpdate = await libraryDbContext.Books.FirstOrDefaultAsync(b => b.Id.Equals(id));
            if (bookToUpdate != null)
            {
                bookToUpdate.Author = book.Author ?? bookToUpdate.Author;
                bookToUpdate.Isbn = book.Isbn ?? bookToUpdate.Isbn;
                bookToUpdate.Title = book.Title ?? bookToUpdate.Title;
                bookToUpdate.Year = book.Year ?? bookToUpdate.Year;
                bookToUpdate.AuthorId = book.AuthorId;

                libraryDbContext.Books.Update(bookToUpdate);
                await libraryDbContext.SaveChangesAsync();
            }

            await libraryDbContext.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var bookToDelete = await libraryDbContext.Books.FirstOrDefaultAsync(b => b.Id.Equals(id));
            if (bookToDelete != null)
            {
                libraryDbContext.Books.Remove(bookToDelete);
                await libraryDbContext.SaveChangesAsync();
            }
        }
    }
}
