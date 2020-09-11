using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookWorm.DAL.Interfaces;
using BookWorm.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookWorm.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepo _authorRepo;

        public AuthorsController(IAuthorRepo authorRepo)
        {
            _authorRepo = authorRepo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var repoAuthors = _authorRepo.GetAllAuthors();
            var returnAuthors = new List<SelectListItem>();
            returnAuthors.Add(new SelectListItem("Create New Author", "0"));
            foreach (var item in repoAuthors)
            {
                returnAuthors.Add(new SelectListItem($"{item.FirstName} {item.LastName}", $"{item.Id}"));
            }
            return Ok(returnAuthors);
        }
    }
}
