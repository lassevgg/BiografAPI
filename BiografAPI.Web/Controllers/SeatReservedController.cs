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
    public class SeatReservedController : Controller
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
            return Json(db.GetSeatReservedList());
        }

        [HttpGet("{id}")]
        public IActionResult List(int id)
        {
            return Json(db.GetSeatReserved(id));
        }

        [HttpPost]
        public IActionResult Insert(int id, int? seatId, int? reservationId, int? screeningId)
        {
            var t = db.CreateSeatReserved(id, seatId, reservationId, screeningId);

            return View();
        }

        [HttpPut]
        public IActionResult Update(int id, int? newSeatIdValue, int? newReservationIdValue, int? newScreeningIdValue)
        {
            var t = db.UpdateSeatReserved(id, newSeatIdValue, newReservationIdValue, newScreeningIdValue);

            return View();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var t = db.DeleteSeatReserved(id);

            return View();
        }
    }
}
