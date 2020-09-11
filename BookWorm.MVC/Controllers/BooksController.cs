using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookWorm.DAL.Interfaces;
using BookWorm.DTO;
using BookWorm.MVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookWorm.MVC.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookRepo _bookRepo;
        private readonly IAuthorRepo _authorRepo;
        private readonly ISeriesRepo _seriesRepo;

        public BooksController(IBookRepo bookRepo, 
                                IAuthorRepo authorRepo,
                                ISeriesRepo seriesRepo)
        {
            _bookRepo = bookRepo;
            _authorRepo = authorRepo;
            _seriesRepo = seriesRepo;
        }

        public IActionResult Index()
        {
            return View(new BooksViewModel()
            {
                Books = _bookRepo.GetAllBooks(),
                BookForm = new BookFormModel()
                {
                    BookForm = new BooksDTO() { Id = 0 },
                    Authors = PopulateAuthorsDropdown(),
                    Series = PopulateSeriesDropdown()
                }
            });
        }

        public IActionResult Details(int id)
        {
            return View(new BookFormModel()
            {
                BookForm = _bookRepo.GetBookById(id),
                Authors = PopulateAuthorsDropdown(),
                Series = PopulateSeriesDropdown()
            });
        }

        public IActionResult DeleteBook(int id)
        {
            if (id > 0)
            {
                _bookRepo.DeleteBook(id);
            }
            else
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditBook(BookFormModel updatedBook)
        {
            if(updatedBook.BookForm.AuthorId == 0)
            {
                GenerateNewAuthor(updatedBook);
            }
            if (updatedBook.BookForm.SeriesId == 0)
            {
                GenerateNewSeries(updatedBook);
            }

            if (ModelState.IsValid && updatedBook.BookForm.Id > 0)
            {
                _bookRepo.UpdateBook(updatedBook.BookForm);
                return RedirectToAction("Details", new { id = updatedBook.BookForm.Id });
            }
            else if(ModelState.IsValid && updatedBook.BookForm.Id == 0)
            {
                _bookRepo.AddBook(updatedBook.BookForm);
                var newBook = _bookRepo.GetLatestBook();
                return RedirectToAction("Details", new { id = newBook.Id });
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


        private List<SelectListItem> PopulateAuthorsDropdown()
        {
            var repoAuthors = _authorRepo.GetAllAuthors();
            var returnAuthors = new List<SelectListItem>();
            returnAuthors.Add(new SelectListItem("Add New Author", "0"));
            foreach (var item in repoAuthors)
            {
                returnAuthors.Add(new SelectListItem($"{item.FirstName} {item.LastName}", $"{item.Id}"));
            }

            return returnAuthors;
        }

        private List<SelectListItem> PopulateSeriesDropdown()
        {
            var repoSeries = _seriesRepo.GetAllSeries();
            var returnSeries = new List<SelectListItem>();
            returnSeries.Add(new SelectListItem("Add New Series", "0"));
            foreach (var item in repoSeries)
            {
                returnSeries.Add(new SelectListItem($"{item.SeriesName}", $"{item.Id}"));
            }

            return returnSeries;
        }

        private void GenerateNewAuthor(BookFormModel updatedBook)
        {
            var addAuthor = new AuthorsDTO()
            {
                Id = 0,
                FirstName = updatedBook.BookForm.FirstName,
                LastName = updatedBook.BookForm.LastName
            };
            _authorRepo.AddAuthor(addAuthor);
            var latestAuthor = _authorRepo.GetLatestAuthor();
            updatedBook.BookForm.AuthorId = latestAuthor.Id;
        }

        private void GenerateNewSeries(BookFormModel updatedBook)
        {
            var addSeries = new SeriesDTO()
            {
                Id = 0,
                SeriesName = updatedBook.BookForm.SeriesName
            };
            _seriesRepo.AddSeries(addSeries);
            var LatestSeries = _seriesRepo.GetLatestSeries();
            updatedBook.BookForm.SeriesId = LatestSeries.Id;
        }
    }
}
