using CalorieTrackingApp.Business.Abstract;
using CalorieTrackingApp.DataAccess.Abstract;
using CalorieTrackingApp.DataAccess.Concrete;
using CalorieTrackingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieTrackingApp.Business.Concrete
{
    public class FoodManager : IFoodService
    {
        private IFoodDal _foodDal;
        public FoodManager(IFoodDal foodDal)
        {
            _foodDal = foodDal;
        }
        public void Create(Food food)
        {

            _foodDal.Create(food);
        }

        public void Delete(Food food)
        {
            _foodDal.Delete(food);
        }

        public List<Food> GetAll()
        {
            return _foodDal.GetAll();
        }

        public Food GetById(int id)
        {
            return _foodDal.GetById(id);
        }

        public List<FoodMealDto> GetFoodMeal(string userId)
        {
            return _foodDal.GetFoodMeal(userId);
        }

        public void Update(Food food)
        {
            _foodDal.Update(food);
        }
    }
}
