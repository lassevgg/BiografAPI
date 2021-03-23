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
    public class ReservationTypeController : Controller
    {
        DatabaseProcedures db = new DatabaseProcedures();

        [HttpGet]
        public IActionResult ListAll()
        {
            return Json(db.GetReservationTypeList());
        }

        [HttpGet("{reservationType}")]
        public IActionResult List([FromBody] ReservationType reservationType)
        {
            return Json(db.GetReservationType(reservationType.Id));
        }

        [HttpPost("{reservationType}")]
        public IActionResult Insert([FromBody] ReservationType reservationType)
        {
            return Ok(db.CreateReservationType(reservationType.Id, reservationType.Type));
        }

        [HttpPut("{reservationType}")]
        public IActionResult Update([FromBody] ReservationType reservationType)
        {
            return Ok(db.UpdateReservationType(reservationType.Id, reservationType.Type));
        }

        [HttpDelete("{reservationType}")]
        public IActionResult Delete([FromBody] ReservationType reservationType)
        {
            return Ok(db.DeleteReservationType(reservationType.Id));
        }
    }
}
