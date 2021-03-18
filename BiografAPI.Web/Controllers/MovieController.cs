using BiografAPI.Web.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BiografAPI.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : Controller
    {
        DatabaseProcedures db = new DatabaseProcedures();

        [HttpGet]
        public IActionResult ListAll()
        {
            return Json(db.GetMovieList());
        }

        [HttpGet("{id}")]
        public IActionResult ListAll(int id)
        {
            return Json(db.GetMovie(id));
        }


        [HttpGet("/Movie/ListAllSortedTitles")]
        public IActionResult ListAllSortedTitles()
        {
            return Json(db.GetMovieList().OrderBy(x => x.Title).ToList());
        }

        [HttpGet("/Movie/ListAllSortedDuration")]
        public IActionResult ListAllSortedDuration()
        {
            return Json(db.GetMovieList().OrderBy(x => x.DurationMin).ToList());
        }

        [HttpGet("/Movie/ListAllSortedGenreTypes")]
        public IActionResult ListAllSortedGenreTypes()
        {
            return Json(db.GetMovieList().OrderBy(x => x.Genre.Type).ToList());
        }

        [HttpGet("/Movie/ListAllGenre")]
        public IActionResult ListAllGenre(string genre)
        {
            return Json(db.GetMovieList().Where(x => x.Genre.Type == genre));
        }


        [HttpPost]
        public async Task<IActionResult> Insert(int id, string title, int genreId, string director, string description, int durationMin)
        {
            var t = db.CreateMovie(id, title, genreId, director, description, durationMin);

            return View();
        }

        [HttpPut]
        public IActionResult Update(int id, string newTitleValue, int? newGenreIdValue, string newDirectorValue, string newDescriptionValue, int? newDurationMin)
        {
            var t = db.UpdateMovie(id, newTitleValue, newGenreIdValue, newDirectorValue, newDescriptionValue, newDurationMin);

            return View();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var t = db.DeleteEmployee(id);

            return View();
        }


        
    }
}
