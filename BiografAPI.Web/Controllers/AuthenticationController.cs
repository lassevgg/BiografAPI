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
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticateService _AuthenticateService;

        public AuthenticationController(IAuthenticateService authenticateService)
        {
            _AuthenticateService = authenticateService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Employee employeeModel)
        {
            var employee = _AuthenticateService.Authenticate(employeeModel.Username, employeeModel.Password);

            if (employee == null)
                return BadRequest(new { message = "Username or Password is incorrect. "}); ;

            return Ok(employee);
        }
    }
}
