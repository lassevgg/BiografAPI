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
    public class SeatReservedController : Controller
    {
        DatabaseProcedures db = new DatabaseProcedures();

        [HttpGet]
        public IActionResult ListAll()
        {
            return Json(db.GetSeatReservedList());
        }

        [HttpGet("seatReserved")]
        public IActionResult List([FromBody] SeatReserved seatReserved)
        {
            return Json(db.GetSeatReserved(seatReserved.Id));
        }

        [HttpPost("seatReserved")]
        public IActionResult Insert([FromBody] SeatReserved seatReserved)
        {
            return Ok(db.CreateSeatReserved(seatReserved.Id, seatReserved.SeatId, seatReserved.ReservationId, seatReserved.ScreeningId));
        }

        [HttpPut("seatReserved")]
        public IActionResult Update([FromBody] SeatReserved seatReserved)
        {
            return Ok(db.UpdateSeatReserved(seatReserved.Id, seatReserved.SeatId, seatReserved.ReservationId, seatReserved.ScreeningId));
        }

        [HttpDelete("seatReserved")]
        public IActionResult Delete([FromBody] SeatReserved seatReserved)
        {
            return Ok(db.DeleteSeatReserved(seatReserved.Id));
        }
    }
}
