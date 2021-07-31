using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieTrackingApp.Entities
{
    public class Meal
    {
        [Key]
        public int Id { get; set; }
        public string Period { get; set; }
        public int FoodId { get; set; }
        public DateTime DateTime { get; set; }
        public string UserId { get; set; }

    }
}
