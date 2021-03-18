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
    public class EmployeeController : Controller
    {
        DatabaseProcedures db = new DatabaseProcedures();

        [HttpGet]
        public IActionResult ListAll()
        {
            return Json(db.GetEmployeeList());
        }

        [HttpGet("{id}")]
        public IActionResult List(int id)
        {
            return Json(db.GetEmployee(id));
        }

        [HttpPost]
        public IActionResult Insert(int id, string username, string password)
        {
            var t = db.CreateEmployee(id, username, password);

            return View();
        }

        [HttpPut]
        public IActionResult Update(int id, string newUsernameValue, string newPasswordValue)
        {
            var t = db.UpdateEmployee(id, newUsernameValue, newPasswordValue);

            return View();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var t = db.DeleteEmployee(id);

            return View();
        }
    }
}
