using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPICRUDEFDemo.EmployeeData;
using RestAPICRUDEFDemo.Models;

namespace RestAPICRUDEFDemo.Controllers
{
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeData _employeeData;

        public EmployeesController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetAllEmployees()
        {
            return Ok(_employeeData.GetEmployees());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmployee(Guid id)
        {
            var _employee = _employeeData.GetEmployee(id);

            if (_employee != null)
            {
                return Ok(_employee);
            }

            return NotFound($"Employee with Id:{id} was not found.");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddEmployee(Employee employee)
        {
            _employeeData.AddEmployee(employee);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id, employee);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var _employee = _employeeData.GetEmployee(id);

            if(_employee != null)
            {
                _employeeData.DeleteEmployee(_employee);
                return Ok();
            }

            return NotFound($"Employee with Id:{id} was not found.");
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditEmployee(Guid id, Employee employee)
        {
            var _existingemployee = _employeeData.GetEmployee(id);

            if (_existingemployee != null)
            {
                employee.Id = _existingemployee.Id;
                _employeeData.EditEmployee(employee);
            }

            return Ok(employee);
        }
    }
}
