using CalorieTrackingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieTrackingApp.DataAccess.Abstract
{
    public interface ICalculatorDal:IRepository<Calculator>
    {
        Calculator GetTargetCaloriByUserId(string UserId);
    }
}
