using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieTrackingApp.UI.Models
{
    public class PersonModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int Height { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int Weight { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int Age { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
    }
}
