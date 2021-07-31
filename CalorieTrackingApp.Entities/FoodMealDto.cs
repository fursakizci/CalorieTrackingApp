using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieTrackingApp.Entities
{
    public class FoodMealDto
    {
        public int Id { get; set; }
        public string FoodName { get; set; }
        public int Calorie{ get; set; }
        public DateTime DateTime{ get; set; }
        public string Period { get; set; }
    }
}
