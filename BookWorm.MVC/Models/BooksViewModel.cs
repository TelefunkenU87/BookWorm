using BookWorm.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWorm.MVC.Models
{
    public class BooksViewModel
    {
        public List<BooksDTO> Books { get; set; }
        public BookFormModel BookForm { get; set; }
    }
}
