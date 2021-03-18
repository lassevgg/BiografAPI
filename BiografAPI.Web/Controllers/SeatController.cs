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
    public class SeatController : Controller
    {
        DatabaseProcedures db = new DatabaseProcedures();

        /*
        [HttpGet]
        [HttpGet("{id}")]
        [HttpPost]
        [HttpPut]
        [HttpDelete]
         */

        [HttpGet]
        public IActionResult ListAll()
        {
            return Json(db.GetSeatList());
        }

        [HttpGet("{id}")]
        public IActionResult List(int id)
        {
            return Json(db.GetSeat(id));
        }

        [HttpPost]
        public IActionResult Insert(int id, int? row, int? number, int? auditoriumId)
        {
            var t = db.CreateSeat(id, row, number, auditoriumId);

            return View();
        }

        [HttpPut]
        public IActionResult Update(int id, int? newRowValue, int? newNumberValue, int? newAuditoriumIdValue)
        {
            var t = db.UpdateSeat(id, newRowValue, newNumberValue, newAuditoriumIdValue);

            return View();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var t = db.DeleteSeat(id);

            return View();
        }
    }
}
