using AngularCoreMongoCRUD.Models;
using AngularCoreMongoCRUD.Services;
using Microsoft.AspNetCore.Mvc;

namespace AngularCoreMongoCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService) => _employeeService = employeeService;

        [HttpGet]
        public async Task<List<Employee>> Get() => await _employeeService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Employee>> Get(string id)
        {
            var employee = await _employeeService.GetAsync(id);

            if (employee is null)
            {
                return NotFound();
            }

            return employee;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Employee newEmployee)
        {
            await _employeeService.CreateAsync(newEmployee);

            return NoContent();
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Employee updatedEmployee)
        {
            var employee = await _employeeService.GetAsync(id);

            if (employee is null)
            {
                return NotFound();
            }

            updatedEmployee.Id = employee.Id;

            await _employeeService.UpdateAsync(id, updatedEmployee);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var employee = await _employeeService.GetAsync(id);

            if (employee is null)
            {
                return NotFound();
            }

            await _employeeService.RemoveAsync(id);

            return NoContent();
        }
    }
}
