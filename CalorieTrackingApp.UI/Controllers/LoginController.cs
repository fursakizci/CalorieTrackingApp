using CalorieTrackingApp.Business.Abstract;
using CalorieTrackingApp.Entities;
using CalorieTrackingApp.UI.Identity;
using CalorieTrackingApp.UI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CalorieTrackingApp.UI.Controllers
{
    
    public class LoginController : Controller
    {

        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;

        public LoginController(UserManager<User> userManager,SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        public async  Task<IActionResult> Index(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);

            if(user == null)
            {
                ModelState.AddModelError("", "Bu kullanici olusturulmamistir");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Kullanici adi veya sifre yanlis");
            return View(model);
        }

        [HttpGet]
        public IActionResult RegisterPage()
        {
            return View(new PersonModel());
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPage(PersonModel model)
        {
           
                var user = new User
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    UserName = model.Username,
                    Height = model.Height,
                    Weight = model.Weight,
                    Age = model.Age,
                    Sex = model.Sex,
                    Email = model.Email
                };

                var result = await _userManager.CreateAsync(user, model.Password);
               
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

            ModelState.AddModelError("", "Bilinmeyen bir hata olustu.");

            return View(model);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Profil()
        {
             var user = await _userManager.GetUserAsync(User);

             var profil = new PersonModel
                {
                   Age = user.Age,
                   Name = user.Name,
                   Surname = user.Surname,
                   Sex = user.Sex,
                   Height = user.Height,
                   Weight = user.Weight,
                   Username = user.UserName
                };
           
            return View(profil);
        }

        [HttpPost]
        public async Task<IActionResult> Profil(PersonModel model)
        {
            var user = await _userManager.GetUserAsync(User);

            user.Name = model.Name;
            user.Surname = model.Surname;
            user.UserName = model.Username;
            user.Height = model.Height;
            user.Weight = model.Weight;
            user.Age = model.Age;
            user.Sex = model.Sex;
           
            IdentityResult x = await _userManager.UpdateAsync(user);
            if (x.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/Dashboard/index");
        }
    }
}
