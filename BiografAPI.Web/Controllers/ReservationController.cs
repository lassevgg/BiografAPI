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
    public class ReservationController : Controller
    {
        DatabaseProcedures db = new DatabaseProcedures();

        [HttpGet]
        public IActionResult ListAll()
        {
            return Json(db.GetReservationList());
        }

        [HttpGet("reservation")]
        public IActionResult List([FromBody] Reservation reservation)
        {
            return Json(db.GetReservation(reservation.Id));
        }

        [HttpPost("reservation")]
        public IActionResult Insert([FromBody] Reservation reservation)
        {
            return Ok(db.CreateReservation(reservation.Id, reservation.ScreeningId, reservation.EmployeeReservedId, reservation.ReservationTypeId, reservation.ReservationContactName, Convert.ToBoolean(reservation.Reserved), reservation.EmployeePaidId, Convert.ToBoolean(reservation.Paid), Convert.ToBoolean(reservation.Active)));
        }

        [HttpPut("reservation")]
        public IActionResult Update([FromBody] Reservation reservation)
        {
            return Ok(db.CreateReservation(reservation.Id, reservation.ScreeningId, reservation.EmployeeReservedId, reservation.ReservationTypeId, reservation.ReservationContactName, Convert.ToBoolean(reservation.Reserved), reservation.EmployeePaidId, Convert.ToBoolean(reservation.Paid), Convert.ToBoolean(reservation.Active)));
        }

        [HttpDelete("reservation")]
        public IActionResult Delete([FromBody] Reservation reservation)
        {
            return Ok(db.DeleteReservations(reservation.Id));
        }
    }
}