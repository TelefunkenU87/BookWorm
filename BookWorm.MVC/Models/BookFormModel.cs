using BookWorm.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWorm.MVC.Models
{
    public class BookFormModel
    {
        public BooksDTO BookForm { get; set; }
        public List<SelectListItem> Authors { get; set; }
    }
}
