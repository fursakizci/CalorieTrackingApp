using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieTrackingApp.UI.Identity
{
    public class User:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        //public int TargetCalorie { get; set; }

    }
}
