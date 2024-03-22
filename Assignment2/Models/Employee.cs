//using System.ComponentModel.DataAnnotations;

//namespace Assignment2.Models
//{
//    public class Employee
//    {
//        public Guid Id { get; set; }
//        [Required]
//        [StringLength(30)]
//        public string Name { get; set; }

//        [Required]
//        [Range(21, 100)]
//        public int Age { get; set; }
//        public string Department { get; set; }    
//        public decimal salary {  get; set; } 

//        public Department Departments {  get; set; }  
//    }
//}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment2.Models
{
    public class Employee
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [Range(21, 100)]
        public int Age { get; set; }

        public decimal Salary { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
