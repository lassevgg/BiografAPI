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
    public class AuditoriumController : Controller
    {
        DatabaseProcedures db = new DatabaseProcedures();

        [HttpGet]
        public IActionResult ListAll()
        {
            return Json(db.GetAuditoriumList());
        }

        [HttpGet]
        public IActionResult List([FromBody] Auditorium auditorium)
        {
            return Json(db.GetAuditorium(auditorium.Id));
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Auditorium auditorium)
        {
            return Ok(db.CreateAuditorium(auditorium.Id, auditorium.Name, Convert.ToInt32(auditorium.SeatsNumber)));
        }

        [HttpPut]
        public IActionResult Update([FromBody] Auditorium auditorium)
        {
            return Ok(db.UpdateAuditorium(auditorium.Id, auditorium.Name, auditorium.SeatsNumber));
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Auditorium auditorium)
        {
            return Ok(db.DeleteAuditorium(auditorium.Id));
        }
    }
}
