using Microsoft.AspNetCore.Mvc;
using EmployeeAPI.Models;
using EmployeeAPI.Service;
using System.Collections.Generic;

namespace EmployeeAPI.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeesController()
        {
            _employeeService = new EmployeeService();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            return Ok(_employeeService.GetAllEmployees());
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Employee employee)
        {
            _employeeService.AddEmployee(employee);
            return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Employee employee)
        {
            var existingEmployee = _employeeService.GetEmployeeById(id);
            if (existingEmployee == null)
            {
                return NotFound();
            }
            employee.Id = id;
            _employeeService.UpdateEmployee(employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            _employeeService.DeleteEmployee(id);
            return NoContent();
        }
    }

}
