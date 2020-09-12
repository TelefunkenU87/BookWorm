using BookWorm.DTO;
using System.Collections.Generic;

namespace BookWorm.MVC.Models
{
    public class BooksViewModel
    {
        public List<BooksDTO> Books { get; set; }
        public BookFormModel BookForm { get; set; }
    }
}
