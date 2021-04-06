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
    public class EmployeeController : Controller
    {
        DatabaseProcedures db = new DatabaseProcedures();

        [HttpGet]
        public IActionResult ListAll()
        {
            return Json(db.GetEmployeeList());
        }

        [HttpGet("employee")]
        public IActionResult List([FromBody]Employee employee)
        {
            return Json(db.GetEmployee(employee.Id));
        }

        [HttpGet("employee/{username}/{password}")]
        public IActionResult Login(string username, string password)
        {
            var userFound = db.GetEmployeeLogin(username, password);

            return Json(userFound);
        }

        [HttpPost("employee")]
        public IActionResult Insert([FromBody] Employee employee)
        {
            return Ok(db.CreateEmployee(employee.Id, employee.Username, employee.Password));
        }

        [HttpPut("employee")]
        public IActionResult Update([FromBody] Employee employee)
        {
            return Ok(db.UpdateEmployee(employee.Id, employee.Username, employee.Password));
        }

        [HttpDelete("employee")]
        public IActionResult Delete([FromBody] Employee employee)
        {
            return Ok(db.DeleteEmployee(employee.Id));
        }
    }
}
