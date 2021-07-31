using CalorieTrackingApp.Business.Abstract;
using CalorieTrackingApp.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieTrackingApp.UI.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Profile()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Profile(PersonModel model)
        {

            return View();
        }
    }
}
