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

            return View(books);
        }

        public IActionResult Details(int id)
        {
            var book = _bookRepo.GetBookById(id);

            return View(book);
        }
    }
}
