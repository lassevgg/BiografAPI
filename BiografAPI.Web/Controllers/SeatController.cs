using BiografAPI.Web.Data;
using BiografAPI.Web.Models;
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

        [HttpGet]
        public IActionResult ListAll()
        {
            return Json(db.GetSeatList());
        }

        [HttpGet]
        public IActionResult List([FromBody] Seat seat)
        {
            return Json(db.GetSeat(seat.Id));
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Seat seat)
        {
            return Ok(db.CreateSeat(seat.Id, seat.Row, seat.Number, seat.AuditoriumId));
        }

        [HttpPut]
        public IActionResult Update([FromBody] Seat seat)
        {
            return Ok(db.UpdateSeat(seat.Id, seat.Row, seat.Number, seat.AuditoriumId));
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Seat seat)
        {
            return Ok(db.DeleteSeat(seat.Id));
        }
    }
}
