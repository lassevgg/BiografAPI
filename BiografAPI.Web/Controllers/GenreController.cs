using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiografAPI.Web.Data;
using Microsoft.AspNetCore.Authorization;
using BiografAPI.Web.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;


namespace BiografAPI.Web.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] 
    [ApiController]
    [Route("[controller]")]
    public class GenreController : Controller
    {
        DatabaseProcedures db = new DatabaseProcedures();

        [HttpGet]
        public IActionResult ListAll()
        {
            return Json(db.GetGenres());
        }

        [HttpGet("genre")]
        public IActionResult ListAll([FromBody] Genre genre)
        {
            return Json(db.GetGenre(genre.Id));
        }

        [HttpPost("genre")]
        public IActionResult Insert([FromBody] Genre genre)
        {
            return Json(db.CreateGenre(genre.Id, genre.Type));
        }

        [HttpPut("genre")]
        public IActionResult Update([FromBody] Genre genre)
        {
            return Json(db.UpdateGenre(genre.Id, genre.Type));
        }

        [HttpDelete("genre")]
        public IActionResult Delete([FromBody] Genre genre)
        {
            return Json(db.DeleteGenre(genre.Id));
        }        
    }
}
