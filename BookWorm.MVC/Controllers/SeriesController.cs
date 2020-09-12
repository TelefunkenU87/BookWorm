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
    public class SeriesController : Controller
    {
        private readonly IBookRepo _bookRepo;
        private readonly IAuthorRepo _authorRepo;
        private readonly ISeriesRepo _seriesRepo;

        public SeriesController(IBookRepo bookRepo,
                                IAuthorRepo authorRepo,
                                ISeriesRepo seriesRepo)
        {
            _bookRepo = bookRepo;
            _authorRepo = authorRepo;
            _seriesRepo = seriesRepo;
        }
        public IActionResult Index()
        {
            return View(new SeriesViewModel()
            {
                Series = _seriesRepo.GetAllSeries(),
                SeriesForm = new SeriesDTO()
            });
        }

        public IActionResult Details(int id)
        {
            return View(new SeriesViewModel()
            {
                SeriesForm = _seriesRepo.GetSeriesById(id),
                SeriesBooks = _bookRepo.GetBooksBySeries(id)
            });
        }

        [HttpPost]
        public IActionResult EditSeries(SeriesDTO updatedSeries)
        {
            if (ModelState.IsValid && updatedSeries.Id > 0)
            {
                _seriesRepo.UpdateSeries(updatedSeries);
                return RedirectToAction("Details", new { id = updatedSeries.Id });
            }
            else if (ModelState.IsValid && updatedSeries.Id == 0)
            {
                _seriesRepo.AddSeries(updatedSeries);
                var newSeries = _seriesRepo.GetLatestSeries();
                return RedirectToAction("Details", new { id = newSeries });
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
