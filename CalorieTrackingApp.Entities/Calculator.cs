using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieTrackingApp.Entities
{
    public class Calculator
    {
        public int Id { get; set; }
        public int TargetCalorie { get; set; }
        public string UserId { get; set; }
    }
}
