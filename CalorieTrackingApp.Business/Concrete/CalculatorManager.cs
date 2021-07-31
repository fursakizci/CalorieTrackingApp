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
    public class CalculatorManager : ICalculatorService
    {
        private ICalculatorDal _calculatorDal;
        public CalculatorManager(ICalculatorDal calculatorDal)
        {
            _calculatorDal = calculatorDal;
        }
        public void CreateAndUpdate(Calculator entity)
        {
            var calculate =_calculatorDal.GetTargetCaloriByUserId(entity.UserId);
            if (calculate != null)
            {
                entity.Id = calculate.Id;
                _calculatorDal.Update(entity);
            }
            else
            {
                _calculatorDal.Create(entity);
            }
        }

        public Calculator GetTargetCalorie(string UserId)
        {
            return _calculatorDal.GetTargetCaloriByUserId(UserId) == null ? new Calculator() : _calculatorDal.GetTargetCaloriByUserId(UserId);
        }
    }
}
