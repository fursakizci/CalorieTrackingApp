using CalorieTrackingApp.DataAccess.Abstract;
using CalorieTrackingApp.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieTrackingApp.DataAccess.Concrete
{
    public class EfFoodDal : EfGenericRepository<Food, CalorieTrackingContext>, IFoodDal
    {
        public List<FoodMealDto> GetFoodMeal(string userId)
        {
            using (var context = new CalorieTrackingContext())
            {

                var entryPoint = (from m in context.Meals
                                  join f in context.Foods on Convert.ToInt32(m.FoodId) equals Convert.ToInt32(f.Id)
                                  where (m.DateTime == DateTime.Now.Date && m.UserId == userId)
                                  select new FoodMealDto
                                  {
                                      Id = m.Id,
                                      FoodName = f.FoodName,
                                      Calorie = f.Calorie,
                                      DateTime = m.DateTime,
                                      Period = m.Period
                                  });
                return entryPoint.ToList();
            }

        }
    }
}
