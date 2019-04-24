using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Models
{
    public class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public string Year { get; set; }

        public string AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}
