using BiografAPI.Web.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiografAPI.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuditoriumController : Controller
    {
        DatabaseProcedures db = new DatabaseProcedures();

        [HttpGet]
        public IActionResult ListAll()
        {
            return Json(db.GetAuditoriumList());
        }

        [HttpGet("{id}")]
        public IActionResult List(int id)
        {
            return Json(db.GetAuditorium(id));
        }

        [HttpPost]
        public IActionResult Insert(int id, string name, int seatsNumber)
        {
            var t = db.CreateAuditorium(id, name, seatsNumber);

            return View();
        }

        [HttpPut]
        public IActionResult Update(int id, string newNameValue, int? newSeatsNumberValue)
        {
            var t = db.UpdateAuditorium(id, newNameValue, newSeatsNumberValue);

            return View();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var t = db.DeleteAuditorium(id);

            return View();
        }
    }
}
