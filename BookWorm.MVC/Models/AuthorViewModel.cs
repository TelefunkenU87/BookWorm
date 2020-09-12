using BookWorm.DTO;
using System.Collections.Generic;

namespace BookWorm.MVC.Models
{
    public class AuthorViewModel
    {
        public List<AuthorsDTO> Authors { get; set; }
        public AuthorsDTO AuthorForm { get; set; }
        public List<BooksDTO> AuthorsBooks { get; set; }
        public List<SeriesDTO> AuthorsSeries { get; set; }
    }
}
