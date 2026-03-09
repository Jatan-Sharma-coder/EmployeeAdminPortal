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

    }
}
