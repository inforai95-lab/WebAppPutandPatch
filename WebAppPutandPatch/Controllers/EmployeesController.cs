using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppPutandPatch.Models;
using WebAppPutandPatch.Repositories;

namespace WebAppPutandPatch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
    public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var emp = await _employeeRepository.GetAllAsync();
            return Ok(emp);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee =
                await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
            {
                return NotFound(new
                {
                    message = "Employee not found"
                });
            }

            return Ok(employee);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdEmployee =
                await _employeeRepository.CreateAsync(employee);

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdEmployee.Id },
                createdEmployee);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id,Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest(new
                {
                    message = "ID mismatch"
                });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result =
                await _employeeRepository.UpdateAsync(employee);

            if (!result)
            {
                return NotFound(new
                {
                    message = "Employee not found"
                });
            }

            return Ok(employee);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result =
                await _employeeRepository.DeleteAsync(id);

            if (!result)
            {
                return NotFound(new
                {
                    message = "Employee not found"
                });
            }

            return Ok(new
            {
                message = "Employee deleted successfully"
            });
        }
        [HttpPatch("{id:int}")]
        [Consumes("application/json-patch+json")]
        public async Task<IActionResult> Patch(int id,[FromBody] JsonPatchDocument<Employee> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest(new
                {
                    message = "Patch document is required"
                });
            }

            var employee =
                await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
            {
                return NotFound(new
                {
                    message = "Employee not found"
                });
            }

            // Apply PATCH operations
            patchDocument.ApplyTo(
                employee,
                error =>
                {
                    ModelState.AddModelError(
                        error.Operation.path,
                        error.ErrorMessage);
                });

            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            // Update database
            var result =
                await _employeeRepository.UpdateAsync(employee);

            if (!result)
            {
                return NotFound(new
                {
                    message = "Employee not found"
                });
            }

            return Ok(employee);
        }
    }
}
