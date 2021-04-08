using BiografAPI.Web.Data;
using BiografAPI.Web.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BiografAPI.Web.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly AppSettings _appSettings;
        DatabaseProcedures db = new DatabaseProcedures();

        public AuthenticateService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public (Employee, string) Authenticate(Employee employeeIn)
        {
            //todo brug db context her til at sammenligne employee brugere..
            //var employee = employeeList.SingleOrDefault(x => x.Username == userName && x.Password == password);

            var userFound = db.GetEmployeeLogin(employeeIn.Username, employeeIn.Password);

            // return null if employee is not found
            if (userFound == null)
                return (null, null);

            (Employee, string) elevatedUser;
            elevatedUser.Item1 = userFound;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, elevatedUser.Item1.Id.ToString()),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.Version, "V3.1")
                }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            elevatedUser.Item2 = tokenHandler.WriteToken(token);

            elevatedUser.Item1.Password = "HIDDEN";

            return elevatedUser;
        }
    }
}
