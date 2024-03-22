using Assignment2.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options):base(options) { }
        public DbSet<Employee> Employees { get; set; }  
        public DbSet<Department> Departments { get; set; }
    }
}
