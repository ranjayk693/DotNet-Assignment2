using System.ComponentModel.DataAnnotations;

namespace Assignment2.Dtos
{
    public class CreateDepartmentDto
    {
        public Guid EmployeeId { get; set; }
        [Required]
        [StringLength(50)]
        public string DepartmentName { get; set; }
    }
}
