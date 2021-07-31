using CalorieTrackingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieTrackingApp.Business.Abstract
{
    public interface IFoodService
    {
        Food GetById(int id);
        List<Food> GetAll();
        void Create(Food food);
        void Update(Food food);
        void Delete(Food food);
        List<FoodMealDto> GetFoodMeal(string userId);

    }
}
