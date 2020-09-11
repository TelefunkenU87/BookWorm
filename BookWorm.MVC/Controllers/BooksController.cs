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

        public BooksController(IBookRepo bookRepo, 
                                IAuthorRepo authorRepo)
        {
            _bookRepo = bookRepo;
            _authorRepo = authorRepo;
        }

        public IActionResult Index()
        {
            var books = _bookRepo.GetAllBooks();
            var repoAuthors = _authorRepo.GetAllAuthors();
            var returnAuthors = new List<SelectListItem>();
            returnAuthors.Add(new SelectListItem("Add New Author", "0"));
            foreach (var item in repoAuthors)
            {
                returnAuthors.Add(new SelectListItem($"{item.FirstName} {item.LastName}", $"{item.Id}"));
            }

            return View(new BooksViewModel()
            {
                Books = books,
                BookForm = new BookFormModel()
                {
                    BookForm = new BooksDTO() { Id = 0 },
                    Authors = returnAuthors
                }
            });
        }

        public IActionResult Details(int id)
        {
            var book = _bookRepo.GetBookById(id);
            var repoAuthors = _authorRepo.GetAllAuthors();
            var returnAuthors = new List<SelectListItem>();
            returnAuthors.Add(new SelectListItem("Add New Author", "0"));
            foreach (var item in repoAuthors)
            {
                returnAuthors.Add(new SelectListItem($"{item.FirstName} {item.LastName}", $"{item.Id}"));
            }

            return View(new BookFormModel()
            {
                BookForm = book,
                Authors = returnAuthors
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
            if(ModelState.IsValid && updatedBook.BookForm.Id > 0)
            {
                _bookRepo.UpdateBook(updatedBook.BookForm);
                return RedirectToAction("Details", new { id = updatedBook.BookForm.Id });
            }
            else if(ModelState.IsValid && updatedBook.BookForm.Id < 1)
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
    }
}
