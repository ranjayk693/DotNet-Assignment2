using Assignment2.Models;
using System.ComponentModel.DataAnnotations;

namespace Assignment2.Dtos
{
    public class CreateEmployeeDto
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [Range(21, 100)]
        public int Age { get; set; }

        public decimal Salary { get; set; }
    }
}
