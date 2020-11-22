using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagment.Models
{
    public class BookCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation Properties
        public ICollection<Book> Books { get; set; } //Using ICollection to be as abstractive as possible
    }
}
