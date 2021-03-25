using BiografAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiografAPI.Web.Services
{
    public interface IAuthenticateService
    {
        (Employee, string) Authenticate(string userName, string password);
    }
}
