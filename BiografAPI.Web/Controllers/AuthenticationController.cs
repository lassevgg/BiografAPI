using BiografAPI.Web.Models;
using BiografAPI.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiografAPI.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]    
    public class AuthenticationController : Controller
    {
        private IAuthenticateService _AuthenticateService;

        public AuthenticationController(IAuthenticateService authenticateService)
        {
            _AuthenticateService = authenticateService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Employee employeeModel)
        {
            (Employee, string) employee = _AuthenticateService.Authenticate(employeeModel);

            if (employee.Item1 == null)
                return BadRequest(new { message = "Username or Password is incorrect. "}); ;

            AdminUser elevatedUser = new AdminUser()
            {
                Username = employee.Item1.Username,
                Password = employee.Item1.Password,
                JwtToken = employee.Item2
            };            

            return Json(elevatedUser);
        }
    }
}