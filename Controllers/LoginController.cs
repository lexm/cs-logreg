using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DbConnection;
using logreg.Models;

namespace logreg.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(Login user)
        {
            if (ModelState.IsValid)
            {
                string Email = user.Email;
                string Password = user.Password;
                string selQuery = string.Format("SELECT Password FROM Users WHERE Email = \"{0}\"", Email);
                List<Dictionary<string, object>> list = DbConnector.Query(selQuery);
                string dbPass = (string)list[0].First().Value;
                if(Password == dbPass)
                {
                    return View("~/Views/User/YouAreIn.cshtml");
                }
                else
                {
                    ModelState.AddModelError("Password", "Login/Password Mismatch");
                    ViewBag.errors = ModelState.Values;
                    return View("~/Views/Login/Login.cshtml", user);
                }
            }
            else
            {
                return View("~/Views/User/YouAreOut.cshtml");
            }
        }
    }
}