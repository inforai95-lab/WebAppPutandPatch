using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPutandPatch.Models
{
   
        public class Employee
        {
            public int Id { get; set; }

            [Required]
            [StringLength(100)]
            public string Name { get; set; }

            [Required]
            [StringLength(100)]
            public string City { get; set; }

            [Required]
            public decimal Salary { get; set; }
        }
}
