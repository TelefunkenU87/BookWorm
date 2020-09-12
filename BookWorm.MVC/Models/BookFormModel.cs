using BookWorm.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BookWorm.MVC.Models
{
    public class BookFormModel
    {
        public BooksDTO BookForm { get; set; }
        public List<SelectListItem> Authors { get; set; }
        public List<SelectListItem> Series { get; set; }
        public IFormFile UploadedCoverArt { get; set; }
    }
}
