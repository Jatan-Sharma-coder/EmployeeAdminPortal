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

        [HttpGet("GetEmployeeById")]
        public IActionResult GetEmployeeById(Guid id)
        {
            return Ok(dbContext.Employees.Find(id));
        }

        [HttpGet("GetEmployeesList")]
        public IActionResult GetEmployeesList()
        {
            return Ok(dbContext.Employees.ToList());
        }

    }
}
