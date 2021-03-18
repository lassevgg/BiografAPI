using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiografAPI.Web.Data;

namespace BiografAPI.Web.Controllers
{
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

        [HttpGet("{id}")]
        public IActionResult ListAll(int id)
        {
            return Json(db.GetGenre(id));
        }

        [HttpPost]
        public IActionResult Insert(int id, string type)
        {
            return Json(db.CreateGenre(id, type));
        }

        [HttpPost("{genre}")]
        public IActionResult InsertObject(BiografAPI.Web.Models.Genre genre)
        {
            //swagger viser alt for meget sammenkoblet?

            //return Json(db.CreateGenre(id, type));
            return null;
        }

        [HttpPut]
        public IActionResult Update(int id, string newTypeValue)
        {
            return Json(db.UpdateGenre(id, newTypeValue));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Json(db.DeleteGenre(id));
        }        
    }
}
