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
    public class ReservationController : Controller
    {
        DatabaseProcedures db = new DatabaseProcedures();

        [HttpGet]
        public IActionResult ListAll()
        {
            return Json(db.GetReservationList());
        }

        [HttpGet("{id}")]
        public IActionResult List(int id)
        {
            return Json(db.GetReservation(id));
        }

        [HttpPost]
        public IActionResult Insert(int id, int? screeningId, int? employeeReservedId, int? reservationTypeId, string reservationContactName, bool reserved, int? employeePaidId, bool paid, bool active)
        {
            var t = db.CreateReservation(id, screeningId, employeeReservedId, reservationTypeId, reservationContactName, reserved, employeePaidId, paid, active);

            return View();
        }

        [HttpPut]
        public IActionResult Update(int id, int? newscreeningIdValue, int? newemployeeReservedIdValue, int? newreservationTypeIdValue, string newreservationContactNameValue, bool newreservedValue, int? newemployeePaidIdValue, bool newpaidValue, bool newactiveValue)
        {
            var t = db.CreateReservation(id, newscreeningIdValue, newemployeeReservedIdValue, newreservationTypeIdValue, newreservationContactNameValue, newreservedValue, newemployeePaidIdValue, newpaidValue, newactiveValue);

            return View();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var t = db.DeleteReservations(id);

            return View();
        }
    }
}