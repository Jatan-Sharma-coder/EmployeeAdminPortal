using EmployeeAdminPortal.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entity;


namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public ApplicationDbContext dbContext;
        public EmployeeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost("CreateNewEmployee")]
        public IActionResult CreateNewEmployee(EmployeeDTO employee)
        {
            var newEmployee = new Employee
            {
                Name = employee.Name,
                Email = employee.Email,
                Phone = employee.Phone,
                Salary = employee.Salary
            };

            dbContext.Employees.Add(newEmployee);
            dbContext.SaveChanges();

            return Ok(newEmployee);
        }

        [HttpGet("GetEmployeeById/{id}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = dbContext.Employees.Find(id);
            if (employee is null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpGet("GetEmployeesList")]
        public IActionResult GetEmployeesList()
        {
            return Ok(dbContext.Employees.ToList());
        }

        [HttpPut("UpdateEmployeeById/{id}")]
        public IActionResult UpdateEmployeeById(Guid id, UpdateEmployeeDTO employee)
        {
            var existingEmployee = dbContext.Employees.Find(id);
            if (existingEmployee is null)
            {
                return NotFound();
            }
            existingEmployee.Name = employee.Name;
            existingEmployee.Email = employee.Email;
            existingEmployee.Phone = employee.Phone;
            existingEmployee.Salary = employee.Salary;
            dbContext.SaveChanges();
            return Ok(existingEmployee);
        }

        [HttpDelete("DeleteEmployeeById/{id}")]
        public IActionResult DeleteEmployeeById(Guid id)
        {
            var existingEmployee = dbContext.Employees.Find(id);
            if (existingEmployee is null)
            {
                return NotFound();
            }
            dbContext.Employees.Remove(existingEmployee);
            dbContext.SaveChanges();
            return Ok(existingEmployee);
        }
    }
}
