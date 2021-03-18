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
    public class ReservationTypeController : Controller
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
            return Json(db.GetReservationTypeList());
        }

        [HttpGet("{id}")]
        public IActionResult List(int id)
        {
            return Json(db.GetReservationType(id));
        }

        [HttpPost]
        public IActionResult Insert(int id, string type)
        {
            var t = db.CreateReservationType(id, type);

            return View();
        }

        [HttpPut]
        public IActionResult Update(int id, string newTypeValue)
        {
            var t = db.UpdateReservationType(id, newTypeValue);

            return View();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var t = db.DeleteReservationType(id);

            return View();
        }
    }
}
