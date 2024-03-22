using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Assignment2.Models
{
    public class Department
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string DepartmentName { get; set; }

        [ForeignKey("EmployeeId")]
        public Guid EmployeeId { get; set; }

        [JsonIgnore]
        public Employee Employee { get; set; }
    }
}