using BiografAPI.Web.Data;
using BiografAPI.Web.Models;
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

        [HttpGet]
        public IActionResult ListAll([FromBody] Movie movie)
        {
            return Json(db.GetMovie(movie.Id));
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

        [HttpGet("/Movie/ListAllSpecificGenre")]
        public IActionResult ListAllSpecificGenre([FromBody] Movie movie)
        {
            return Json(db.GetMovieList().Where(x => x.Genre.Type == movie.Genre.Type));
        }


        [HttpPost]
        public IActionResult Insert([FromBody] Movie movie)
        {
            return Ok(db.CreateMovie(movie.Id, movie.Title, Convert.ToInt32(movie.GenreId), movie.Director, movie.Description, Convert.ToInt32(movie.DurationMin)));
        }

        [HttpPut]
        public IActionResult Update([FromBody] Movie movie)
        {
            return Ok(db.UpdateMovie(movie.Id, movie.Title, movie.GenreId, movie.Director, movie.Description, movie.DurationMin));
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Movie movie)
        {
            return Ok(db.DeleteEmployee(movie.Id));
        }        
    }
}
