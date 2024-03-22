
using Assignment2.Data;
using Assignment2.Dtos;
using Assignment2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public EmployeeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /*API for Employee and Departement relation data*/
        [HttpGet("AllData")]
        public async Task<ActionResult<List<Employee>>> GetAll()
        {
            var data = await _dataContext.Employees
                                   .Include(e => e.Departments)
                                   .ToListAsync();
            return Ok(data);
        }

        /*API for employee details only*/
        [HttpGet("Employee")]
        public async Task<ActionResult<List<EmployeeDtos>>> GetEmployee()
        {
            var data = await _dataContext.Employees.ToListAsync();
            var newData = data.Select(employee => new EmployeeDtos
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Salary = employee.Salary,
            }).ToList();
            return Ok(newData);
        }

        [HttpGet("Employee{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(Guid id)
        {
            var data = await _dataContext.Employees.FirstOrDefaultAsync(elem=>elem.Id==id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpDelete("EmployeeDelete")]
        public async Task<ActionResult> DeleteData(Guid id)
        {
            var data = await _dataContext.Employees.FirstOrDefaultAsync(elem => elem.Id == id);
            if (data == null)
            {
                return NotFound();
            }
            _dataContext.Employees.Remove(data);
            await _dataContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("Departement{id}")]
        public async Task<ActionResult<DepartmentDtos>> GetDepartmentById(Guid id)
        {
            var data = await _dataContext.Departments.FirstOrDefaultAsync(elem => elem.Id == id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }


        /*API for Departement details only*/
        [HttpGet("Departement")]
        public async Task<ActionResult<List<DepartmentDtos>>> GetDepartment()
        {
            var data = await _dataContext.Departments.ToListAsync();
            var newData = data.Select(employee => new DepartmentDtos
            {
                Id = employee.Id,
                DepartmentName=employee.DepartmentName,
            }).ToList();
            return Ok(newData);
        }

       


        /*API for adding new employee*/
        [HttpPost("Employee")]  
        public async Task<ActionResult<CreateEmployeeDto>> PostEmployee(CreateEmployeeDto data){
            var newDAta = new Employee
            {
                Id=Guid.NewGuid(),
                Name = data.Name,
                Age= data.Age,  
                Salary= data.Salary,    
            };

            _dataContext.Employees.Add(newDAta);
            await _dataContext.SaveChangesAsync();
            return  Ok(newDAta);
        }

       

        /*Employee for adding new Departement*/
        [HttpPost("Department")]
        public async Task<ActionResult<CreateDepartmentDto>> PostDepartement(CreateDepartmentDto data)
        {
            var newDAta = new Department
            {
                Id= Guid.NewGuid(),
                EmployeeId=data.EmployeeId,
                DepartmentName= data.DepartmentName,

            };
            _dataContext.Departments.Add(newDAta);
            await _dataContext.SaveChangesAsync();
            return Ok(newDAta);
        }

        [HttpDelete("Department")]
        public async Task<ActionResult> DeleteDepartment(Guid id)
        {
            var data = await _dataContext.Departments.FirstOrDefaultAsync(elem => elem.Id == id);
            if (data == null)
            {
                return NotFound();
            }
            _dataContext.Departments.Remove(data);
            await _dataContext.SaveChangesAsync();
            return NoContent();
        }

    }
}
