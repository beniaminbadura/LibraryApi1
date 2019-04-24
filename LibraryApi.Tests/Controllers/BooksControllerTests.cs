using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LibraryApi.Controllers;
using LibraryApi.Models;
using LibraryApi.Repository;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace LibraryApi.Tests.Controllers
{
    public class BooksControllerTests
    {
        private IBooksRepository repo;

        public BooksControllerTests()
        {
            repo = LibraryContextMocker.GetInMemoryBooksRepository(nameof(BooksControllerTests));

        }

        [Test]
        public async Task get_all_books()
        {
            var controller = new BooksController(repo);

            var response = await controller.Get() as ObjectResult;
            var books = response.Value as List<Book>;

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual(4, books.Count);

        }

        [Test]
        public async Task get_one_book()
        {
            var controller = new BooksController(repo);

            var response = await controller.Get("0") as ObjectResult;
            var book = response.Value as Book;

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("0", book.Id);
        }

        [Test]
        public async Task insert_book()
        {
            var controller = new BooksController(repo);

            var bookToInsert = new Book
            {
                Id = "701",
                Isbn = "ISBN 701",
                Title = "Title 701",
                Year = "2000"
            };

            var response = await controller.Post(bookToInsert) as ObjectResult;

            Assert.AreEqual(200, response.StatusCode);
        }

        [Test]
        public async Task update_book()
        {
            var controller = new BooksController(repo);

            var bookToUpdate = new Book
            {
                Isbn = "ISBN 41",
                Title = "Title 41",
                Year = "2010"
            };

            var response = await controller.Put("1",bookToUpdate) as ObjectResult;

            Assert.AreEqual(200, response.StatusCode);
        }

        [Test]
        public async Task remove_book()
        {
            var controller = new BooksController(repo);
    
            var response = await controller.Delete("0") as ObjectResult;

            Assert.AreEqual(200, response.StatusCode);
        }
    }
}
