using CalorieTrackingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieTrackingApp.DataAccess.Abstract
{
    public interface IMealDal:IRepository<Meal>
    {
        void CreateMeal(Meal meal);
        Tuple<List<int>, List<string>> WeeklyData(string userId);
        
        
    }
}
