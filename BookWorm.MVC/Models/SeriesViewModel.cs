using BookWorm.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWorm.MVC.Models
{
    public class SeriesViewModel
    {
        public List<SeriesDTO> Series { get; set; }
        public SeriesDTO SeriesForm { get; set; }
        public List<BooksDTO> SeriesBooks { get; set; }
        public List<AuthorsDTO> SeriesAuthor { get; set; }
    }
}
