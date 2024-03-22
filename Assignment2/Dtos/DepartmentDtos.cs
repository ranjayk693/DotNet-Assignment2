using Assignment2.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Assignment2.Dtos
{
    public class DepartmentDtos
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string DepartmentName { get; set; }
    }
}
