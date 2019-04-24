using LibraryApi.Context;
using LibraryApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApi.Tests
{
    public static class LibraryContextExtensions
    {
        public static void FillBooksDb(this LibraryDbContext context)
        {
            context.Books.Add(
                new Book
                {
                    Id = "0",
                    Isbn = "Isbn 0",
                    Title = "Title 0",
                    Year = "2019"
                }
            );

            context.Books.Add(
                new Book
                {
                    Id = "1",
                    Isbn = "Isbn 1",
                    Title = "Title 1",
                    Year = "2018"
                }
            );

            context.Books.Add(
                new Book
                {
                    Id = "2",
                    Isbn = "Isbn 2",
                    Title = "Title 2",
                    Year = "2019"
                }
            );

            context.Books.Add(
                new Book
                {
                    Id = "3",
                    Isbn = "Isbn 3",
                    Title = "Title 3",
                    Year = "2017"
                }
            );

            context.SaveChanges();

        }

        public static void FillAuthorsDb(this LibraryDbContext context)
        {
            context.Authors.Add(
                new Author
                {
                    Id = "0",
                    FirstName = "Imie0",
                    LastName = "Nazwisko0",
                }
            );
            context.Authors.Add(
               new Author
               {
                   Id = "1",
                   FirstName = "Imie1",
                   LastName = "Nazwisko2",
               }
           );
            context.Authors.Add(
               new Author
               {
                   Id = "2",
                   FirstName = "Imie2",
                   LastName = "Nazwisko2",
               }
           );


            context.SaveChanges();
        }
    }
}
