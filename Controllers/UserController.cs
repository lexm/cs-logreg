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
        public IActionResult Method()
        {
            User NewUser = new User
            {
                FirstName = "First",
                LastName = "Last",
                Email = "email@example.com",
                Password = "password"
            };

            TryValidateModel(NewUser);
            ViewBag.errors = ModelState.Values;
            return View();
        }
    }
}