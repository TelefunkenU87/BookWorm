using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookWorm.DAL.Interfaces;
using BookWorm.DTO;

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
            var newBook = new BooksDTO();
            newBook.Id = 0;
            books.Add(newBook);

            return View(books);
        }

        public IActionResult Details(int id)
        {
            var book = _bookRepo.GetBookById(id);

            return View(book);
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
        public IActionResult EditBook(BooksDTO updatedBook)
        {
            if(ModelState.IsValid && updatedBook.Id > 0)
            {
                _bookRepo.UpdateBook(updatedBook);
                return RedirectToAction("Details", new { id = updatedBook.Id });
            }
            else if(ModelState.IsValid && updatedBook.Id < 1)
            {
                _bookRepo.AddBook(updatedBook);
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
