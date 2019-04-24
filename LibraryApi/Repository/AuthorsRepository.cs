using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApi.Context;
using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Repository
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private LibraryDbContext libraryDbContext;
        public AuthorsRepository(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await libraryDbContext.Authors.Include(a => a.Books).ToListAsync();
        }

        public async Task<Author> Get(string id)
        {
            return await libraryDbContext.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.Id.Equals(id));
        }

        public async Task Add(Author author)
        {
            await libraryDbContext.Authors.AddAsync(author);
            await libraryDbContext.SaveChangesAsync();
        }

        public async Task Update(string id, Author author)
        {
            var authorToUpdate = await libraryDbContext.Authors.FirstOrDefaultAsync(a => a.Id.Equals(id));
            if (authorToUpdate != null)
            {

                libraryDbContext.Authors.Update(authorToUpdate);
                await libraryDbContext.SaveChangesAsync();
            }

            await libraryDbContext.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            
            var authorToDelete = await libraryDbContext.Authors.FirstOrDefaultAsync(b => b.Id.Equals(id));
            if (authorToDelete != null)
            {
                await libraryDbContext.Books.Where(b => b.AuthorId.Equals(id))
                    .ForEachAsync(b => b.AuthorId = null);
                libraryDbContext.Authors.Remove(authorToDelete);
                await libraryDbContext.SaveChangesAsync();
            }
        }
    }
}
