using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DbConnection;
using logreg.Models;

namespace logreg.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Reg()
        {
            return View();
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(User user)
        {
            if(ModelState.IsValid)
            {
                string FirstName = user.FirstName;
                System.Console.WriteLine(FirstName);
                string LastName = user.LastName;
                System.Console.WriteLine(LastName);
                string Email = user.Email;
                System.Console.WriteLine(Email);
                string Password = user.Password;
                System.Console.WriteLine(Password);
                string insQuery = string.Format("INSERT into Users (FirstName, LastName, Email, Password) VALUES (\"{0}\", \"{1}\", \"{2}\", \"{3}\");", FirstName, LastName, Email, Password);
                DbConnector.Execute(insQuery);
                return RedirectToAction("YouAreIn", user);
            }
            else
            {
                ViewBag.errors = ModelState.Values;
                return View("~/Views/User/Reg.cshtml", user);
            }
        }

        [HttpGet]
        [Route("in")]
        public IActionResult YouAreIn()
        {
            return View("~/Views/User/YouAreIn.cshtml");
        }
    }
}