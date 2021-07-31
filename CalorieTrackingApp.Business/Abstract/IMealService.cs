using CalorieTrackingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieTrackingApp.Business.Abstract
{
    public interface IMealService
    {
        void Create(Meal meal);
        void CreateMeal(Meal meal);
        Tuple<List<int>, List<string>> WeeklyData(string userId);
        void Delete(Meal meal);
        Meal GetById(int id);
        
    }
}
