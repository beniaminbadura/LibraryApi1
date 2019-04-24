using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApi.Models;
using LibraryApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private IAuthorsRepository authorsRepository;
        public AuthorsController(IAuthorsRepository repo)
        {
            authorsRepository = repo;
        }


        // GET api/authors
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await authorsRepository.GetAllAsync();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // GET api/authors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await authorsRepository.Get(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST api/authors
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Author value)
        {
            if (value == null)
            {
                return BadRequest("Author is empty");
            }
            await authorsRepository.Add(value);

            return Ok("Author created");
        }

        // PUT api/authors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Author value)
        {
            if (value == null)
            {
                return BadRequest("Author is empty");
            }
            await authorsRepository.Update(id, value);

            return Ok("Author updated");
        }

        // DELETE api/authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await authorsRepository.Delete(id);

            return Ok("Author deleted");
        }
    }
}