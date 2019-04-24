using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApi.Models;
using LibraryApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBooksRepository booksRepository;
        public BooksController(IBooksRepository repo)
        {
            booksRepository = repo;
        }


        // GET api/books
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await booksRepository.GetAllAsync();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await booksRepository.Get(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST api/books
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Book value)
        {
            if (value == null)
            {
                return BadRequest("Book is empty");
            }
            await booksRepository.Add(value);

            return Ok("Book created");
        }

        // PUT api/books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Book value)
        {
            if (value == null)
            {
                return BadRequest("Book is empty");
            }
            await booksRepository.Update(id,value);

            return Ok("Book updated");
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await booksRepository.Delete(id);

            return Ok("Book deleted");
        }
    }
}
