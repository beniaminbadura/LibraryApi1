using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApi.Models;

namespace LibraryApi.Repository
{
    public interface IBooksRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> Get(string id);
        Task Add(Book book);
        Task Update(string id, Book book);
        Task Delete(string id);
    }
}
