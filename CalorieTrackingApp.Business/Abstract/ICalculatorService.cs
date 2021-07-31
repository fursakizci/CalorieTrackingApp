using CalorieTrackingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieTrackingApp.Business.Abstract
{
    public interface ICalculatorService
    {
        void CreateAndUpdate(Calculator entity);

        Calculator GetTargetCalorie(string UserId);
        
    }
}
