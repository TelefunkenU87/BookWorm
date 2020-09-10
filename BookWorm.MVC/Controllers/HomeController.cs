using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BookWorm.MVC.Models;
using BookWorm.DAL.Interfaces;

namespace BookWorm.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAuthorRepo _authorRepo;

        public HomeController(ILogger<HomeController> logger,
                                IAuthorRepo authorRepo)
        {
            _logger = logger;
            _authorRepo = authorRepo;
        }

        public IActionResult Index()
        {
            var authors = _authorRepo.GetAllAuthors();

            return View(authors);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
