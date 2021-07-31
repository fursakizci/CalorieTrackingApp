using CalorieTrackingApp.Business.Abstract;
using CalorieTrackingApp.DataAccess.Abstract;
using CalorieTrackingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieTrackingApp.Business.Concrete
{
    public class MealManager : IMealService
    {
        private IMealDal _mealDal;
        public MealManager(IMealDal mealDal)
        {
            _mealDal = mealDal;
        }
        public void Create(Meal meal)
        {
            _mealDal.Create(meal);
        }

        public void CreateMeal(Meal meal)
        {
            _mealDal.CreateMeal(meal);
        }

        public void Delete(Meal meal)
        {
            _mealDal.Delete(meal);
        }

        public Meal GetById(int id)
        {
            return _mealDal.GetById(id);
        }

        Tuple<List<int>, List<string>> IMealService.WeeklyData(string userId)
        {
            return _mealDal.WeeklyData(userId);
        }
    }
}
