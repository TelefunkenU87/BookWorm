using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookWorm.DAL.Interfaces;
using BookWorm.DTO;
using BookWorm.MVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;

namespace BookWorm.MVC.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IBookRepo _bookRepo;
        private readonly IAuthorRepo _authorRepo;
        private readonly ISeriesRepo _seriesRepo;

        public AuthorsController(IBookRepo bookRepo,
                                IAuthorRepo authorRepo,
                                ISeriesRepo seriesRepo)
        {
            _bookRepo = bookRepo;
            _authorRepo = authorRepo;
            _seriesRepo = seriesRepo;
        }

        public IActionResult Index()
        {
            return View(new AuthorViewModel()
            {
                Authors = _authorRepo.GetAllAuthors(),
                AuthorForm = new AuthorsDTO()
            });
        }

        public IActionResult Details(int id)
        {
            return View(new AuthorViewModel()
            {
                AuthorForm = _authorRepo.GetAuthorById(id),
                AuthorsBooks = _bookRepo.GetBookByAuthor(id)
            });
        }

        [HttpPost]
        public IActionResult EditAuthor(AuthorsDTO updatedAuthor)
        {
            if (ModelState.IsValid && updatedAuthor.Id > 0)
            {
                _authorRepo.UpdateAuthor(updatedAuthor);
                return RedirectToAction("Details", new { id = updatedAuthor.Id });
            }
            else if(ModelState.IsValid && updatedAuthor.Id == 0)
            {
                _authorRepo.AddAuthor(updatedAuthor);
                var newAuthor = _authorRepo.GetLatestAuthor();
                return RedirectToAction("Details", new { id = newAuthor });
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
