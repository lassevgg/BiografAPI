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

        [HttpGet("ListSeatsOnAuditoriumId/{auditoriumId}")]
        public IActionResult ListSeatsOnAuditoriumId(int? auditoriumId)
        {
            var t = db.GetSeatList().Where(x => x.AuditoriumId == auditoriumId);

            int maxAntalRækker = (int)t.Max(x => x.Row);
            int maxAntalSædeNumre = (int)t.Max(x => x.Number);

            //4 er rows,
            //3 er antallet af sæder i en row, bliver nød til at være en statisk værdi da sæde rækker ikke kan deviere på den her måde.
            //kan måske lade sig gøre ved blot at angive de ikke eksisterende sæder i midter rækken som null?

            //int?[,] array = new int?[4, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };
            
            //int?[,] array = new int?[maxAntalRækker, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };

            return Json(t);
        }

        [HttpGet("seat")]
        public IActionResult List([FromBody] Seat seat)
        {
            return Json(db.GetSeat(seat.Id));
        }

        [HttpPost("seat")]
        public IActionResult Insert([FromBody] Seat seat)
        {
            return Ok(db.CreateSeat(seat.Id, seat.Row, seat.Number, seat.AuditoriumId));
        }

        [HttpPut("seat")]
        public IActionResult Update([FromBody] Seat seat)
        {
            return Ok(db.UpdateSeat(seat.Id, seat.Row, seat.Number, seat.AuditoriumId));
        }

        [HttpDelete("seat")]
        public IActionResult Delete([FromBody] Seat seat)
        {
            return Ok(db.DeleteSeat(seat.Id));
        }
    }
}
