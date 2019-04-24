using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApi.Models;

namespace LibraryApi.Repository
{
    public interface IAuthorsRepository
    {
        Task<IEnumerable<Author>> GetAllAsync();
        Task<Author> Get(string id);
        Task Add(Author author);
        Task Update(string id, Author author);
        Task Delete(string id);
    }
}
