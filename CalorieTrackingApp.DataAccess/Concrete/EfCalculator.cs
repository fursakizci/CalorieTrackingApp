using CalorieTrackingApp.DataAccess.Abstract;
using CalorieTrackingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CalorieTrackingApp.DataAccess.Concrete
{
    public class EfCalculator:EfGenericRepository<Calculator,CalorieTrackingContext>,ICalculatorDal
    {
        public Calculator GetTargetCaloriByUserId(string UserId)
        {
            using (var context = new CalorieTrackingContext())
            {
               return context.Set<Calculator>().Where(u => u.UserId == UserId).FirstOrDefault();
                
            }
        }
    }
}
