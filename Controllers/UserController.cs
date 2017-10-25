using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using logreg.Models;

namespace logreg.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Reg()
        {
            User NewUser = new User
            {
                FirstName = "First",
                LastName = "Last",
                Email = "email@example.com",
                Password = "password",
                Confirm = "password",
            };

            TryValidateModel(NewUser);
            ViewBag.errors = ModelState.Values;
            return View();
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(User user)
        {
            if(ModelState.IsValid)
            {
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