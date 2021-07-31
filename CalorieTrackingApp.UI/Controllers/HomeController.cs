using CalorieTrackingApp.Business.Abstract;
using CalorieTrackingApp.Entities;
using CalorieTrackingApp.UI.Identity;
using CalorieTrackingApp.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieTrackingApp.UI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IFoodService _foodService;
        private IMealService _mealService;
        private ICalculatorService _calculatorService;

        private UserManager<User> _userManager;
      
        public HomeController(ICalculatorService calculatorService,UserManager<User> userManager,ILogger<HomeController> logger, IFoodService foodService , IMealService mealService)
        {
            _logger = logger;
            _foodService = foodService;
            _mealService = mealService;
            _userManager = userManager;
            _calculatorService = calculatorService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            var profil = new PersonModel 
            { 
                Username = user.UserName,
                Height = user.Height,
                Weight = user.Weight,
                Email = user.Email
            };

            var targetCalorie = _calculatorService.GetTargetCalorie(_userManager.GetUserId(User));

            ViewData["targetCalorie"] = targetCalorie.TargetCalorie == 0 ? 1 : targetCalorie.TargetCalorie;
            ViewData["username"] = profil.Username;
            ViewData["email"] = profil.Email;
            ViewData["height"] = profil.Height;
            ViewData["weight"] = profil.Weight;

            List<Food> foods = _foodService.GetAll();
            List<FoodMealDto> foodMealDto = _foodService.GetFoodMeal(_userManager.GetUserId(User));
            ProfileModel model = new ProfileModel
            {
                FoodMealDtos = foodMealDto,
                Foods = foods
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(FoodModel model)
        {
            var userId = _userManager.GetUserId(User);
            var dateTime = Convert.ToDateTime(model.DateTime);
            Meal meal = new Meal
            {
                Period = model.MealId,
                FoodId = model.FoodId,
                DateTime = dateTime,
                UserId = userId
            };

            _mealService.CreateMeal(meal);
            return RedirectToAction("Index");
        }
       
        [HttpGet]
        public IActionResult FoodMeal()
        {
            List<Food> foods = new List<Food>();
            foods = _foodService.GetAll();
            
            return View(foods);
        }

        [HttpPost]
        public IActionResult FoodMeal(FoodModel model)
        {
           var userId = _userManager.GetUserId(User);
           var dateTime = Convert.ToDateTime(model.DateTime);
            Meal meal = new Meal 
            {
                Period = model.MealId,
                FoodId = model.FoodId,
                DateTime = dateTime,
                UserId = userId
            };
           
            _mealService.CreateMeal(meal);

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Profil()
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = _userManager.GetUserId(User);
            Tuple<List<int>, List<string>> datas = _mealService.WeeklyData(userId);

            var profil = new PersonModel
            {
                Height = user.Height,
                Weight = user.Weight,
                Username = user.UserName,
                Email = user.Email
            };

            var targetCalorie = _calculatorService.GetTargetCalorie(userId);

            ViewData["targetCalorie"] = targetCalorie.TargetCalorie == 0 ? 1 : targetCalorie.TargetCalorie;
            ViewData["username"] = profil.Username;
            ViewData["email"] = profil.Email;
            ViewData["height"] = profil.Height;
            ViewData["weight"] = profil.Weight;

            return View(datas);
        }

        public IActionResult DeleteMeal(int id)
        {
            var meal = _mealService.GetById(id);
            _mealService.Delete(meal);
            return RedirectToAction("index","home");
        }

        [HttpGet]
        public IActionResult CalorieCalculator()
        {
            ViewData["UserId"] = _userManager.GetUserId(User);
            return View();
        }

        [HttpPost]
        public IActionResult CalorieCalculator(Calculator calculator)
        {

            _calculatorService.CreateAndUpdate(calculator);
            return RedirectToAction("profil","home");
        }

    }
}
