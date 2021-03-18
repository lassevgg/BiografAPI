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
    public class MovieJOINSController : Controller
    {
        DatabaseProcedures db = new DatabaseProcedures();

        [HttpGet]
        public async Task<IActionResult> JoinMovieGenre()
        {
            var t = await new StreamReader(Request.Body).ReadToEndAsync(); //bare eksempel. Body får ikke noget ind i sig? todo

            var joined = from movie in db.GetMovieList()
                         join genre in db.GetGenres() on movie.GenreId equals genre.Id
                         select movie.Title;

            return Json(joined);
        }
    }
}
