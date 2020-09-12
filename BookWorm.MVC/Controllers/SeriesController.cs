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
using Microsoft.AspNetCore.Http;

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
            var series = new List<SeriesDTO>();
            try
            {
                var result = _seriesRepo.GetAllSeries();

                if (result == null)
                {
                    return NotFound();
                }

                series = result;
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
            return View(new SeriesViewModel()
            {
                Series = series,
                SeriesForm = new SeriesDTO()
            });
        }

        public IActionResult Details(int id)
        {
            var seriesForm = new SeriesDTO();
            try
            {
                var result = _seriesRepo.GetSeriesById(id);

                if (result == null)
                {
                    return NotFound();
                }

                seriesForm = result;
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
            return View(new SeriesViewModel()
            {
                SeriesForm = seriesForm,
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
