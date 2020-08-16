using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KudVenkatEmploymentPortal.Models
{
    public class Employee
    {
        
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public Dept Dept { get; set; }

        public string PhotoPath { get; set; }
    }
}
