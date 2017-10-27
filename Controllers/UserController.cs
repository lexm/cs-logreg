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
                string Email = user.Email;
                string selQuery = string.Format("SELECT Password FROM Users WHERE Email = \"{0}\"", Email);
                System.Console.WriteLine(selQuery);
                List<Dictionary<string, object>> list = DbConnector.Query(selQuery);
                System.Console.WriteLine(list.Count);
                // int count = 1;
                if(list.Count > 0)
                {
                    ModelState.AddModelError("Email", "This Email is already registered.");
                    ViewBag.errors = ModelState.Values;
                    return View("~/Views/User/Reg.cshtml", user);
                }
                else
                {
                    string FirstName = user.FirstName;
                    string LastName = user.LastName;
                    string Password = user.Password;
                    string insQuery = string.Format("INSERT into Users (FirstName, LastName, Email, Password) VALUES (\"{0}\", \"{1}\", \"{2}\", \"{3}\");", FirstName, LastName, Email, Password);
                    DbConnector.Execute(insQuery);
                    return RedirectToAction("YouAreIn");
                }

            }
            else
            {
                foreach(KeyValuePair<string, Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry> pair in ModelState)
                {
                   System.Console.WriteLine("Key is {0}, Value is {1}", pair.Key, pair.Value);
                }
                // foreach (Dictionary<string, object> item in ModelState)
                // {
                //     // System.Console.WriteLine(count);
                //     // count++;
                // }
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