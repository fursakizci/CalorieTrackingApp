﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieTrackingApp.Entities
{
    public class Food
    {
        [Key]
        public int Id { get; set; }
        public string FoodName { get; set; }
        public int Calorie { get; set; }
    }
}
