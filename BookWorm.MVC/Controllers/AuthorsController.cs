using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BookWorm.DAL.Interfaces;
using BookWorm.DTO;
using BookWorm.MVC.Models;
using Microsoft.AspNetCore.Http;

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
            var authors = new List<AuthorsDTO>();
            try
            {
                var result = _authorRepo.GetAllAuthors();

                if (result == null)
                {
                    return NotFound();
                }

                authors = result;
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
            return View(new AuthorViewModel()
            {
                Authors = authors,
                AuthorForm = new AuthorsDTO()
            });
        }

        public IActionResult Details(int id)
        {
            var authorForm = new AuthorsDTO();
            try
            {
                var result = _authorRepo.GetAuthorById(id);

                if (result == null)
                {
                    return NotFound();
                }

                authorForm = result;
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return View(new AuthorViewModel()
            {
                AuthorForm = authorForm,
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
