using CalorieTrackingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieTrackingApp.UI.Models
{
    public class ProfileModel
    {
        public List<Food> Foods { get; set; }
        public List<FoodMealDto> FoodMealDtos{ get; set; }
    }
}
