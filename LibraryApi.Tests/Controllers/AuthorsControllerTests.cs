using LibraryApi.Controllers;
using LibraryApi.Models;
using LibraryApi.Repository;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApi.Tests.Controllers
{
    public class AuthorsControllerTests
    {
        private IAuthorsRepository authorsRepository;
        public AuthorsControllerTests()
        {
            authorsRepository = LibraryContextMocker.GetInMemoryAuthorRepository(nameof(AuthorsControllerTests));
        }


        [Test]
        public async Task get_all_authors()
        {
            var controller = new AuthorsController(authorsRepository);

            var response = await controller.Get() as ObjectResult;
            var authors = response.Value as List<Author>;

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual(3, authors.Count);
        }

        [Test]
        public async Task get_one_author()
        {
            var controller = new AuthorsController(authorsRepository);

            var response = await controller.Get("0") as ObjectResult;
            var author = response.Value as Author;

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("0", author.Id);
        }
        [Test]
        public async Task insert_author()
        {
            var controller = new AuthorsController(authorsRepository);

            var authorToInsert = new Author
            {
                Id = "5",
                FirstName = "Imie5",
                LastName = "Nazwisko5",
            };

            var response = await controller.Post(authorToInsert) as ObjectResult;

            Assert.AreEqual(200, response.StatusCode);
        }


        [Test]
        public async Task update_author()
        {
            var controller = new AuthorsController(authorsRepository);

            var authorToUpdate = new Author
            {
                FirstName = "Imie7",
                LastName = "Nazwisko7",
            };

            var response = await controller.Put("1", authorToUpdate) as ObjectResult;

            Assert.AreEqual(200, response.StatusCode);
        }

        [Test]
        public async Task remove_book()
        {
            var controller = new AuthorsController(authorsRepository);

            var response = await controller.Delete("0") as ObjectResult;

            Assert.AreEqual(200, response.StatusCode);
        }
    }
}
