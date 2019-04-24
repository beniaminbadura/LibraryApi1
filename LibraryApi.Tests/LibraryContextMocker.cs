using LibraryApi.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using LibraryApi.Context;

namespace LibraryApi.Tests
{
    public static class LibraryContextMocker
    {
        public static IBooksRepository GetInMemoryBooksRepository(string dbName)
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            var dbContext = new LibraryDbContext(options);
            dbContext.FillBooksDb();

            return new BooksRepository(dbContext);
        }

        internal static IAuthorsRepository GetInMemoryAuthorRepository(string dbName)
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>()
               .UseInMemoryDatabase(databaseName: dbName)
               .Options;

            var dbContext = new LibraryDbContext(options);
            dbContext.FillAuthorsDb();

            return new AuthorsRepository(dbContext);
        }
    }
}
