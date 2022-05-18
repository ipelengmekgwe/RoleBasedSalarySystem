using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RoleBasedSalarySystem.Core.Interfaces;
using RoleBasedSalarySystem.Models;
using System.Threading.Tasks;

namespace RoleBasedSalarySystem.API.Controllers
{
    public class EmployeesController : BaseApiController
    {
        private readonly ILogger<EmployeesController> _logger;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(ILogger<EmployeesController> logger, IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            _logger.LogInformation($"Getting employee with ID: {id}");

            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);

            if (employee == null) return NotFound();

            return Ok(employee);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            _logger.LogInformation($"Getting all employees");

            var employees = await _employeeRepository.GetEmployeesAsync();

            return Ok(employees);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeModel employeeModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _logger.LogInformation($"Creating new employee");

            var employee = await _employeeRepository.CreateEmployeeAsync(employeeModel);

            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            _logger.LogInformation($"Deleting role with ID: {id}");

            var deleted = await _employeeRepository.DeleteEmployeeAsync(id);

            return Ok(deleted);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateRole([FromBody] EmployeeModel employeeModel)
        {
            if (!ModelState.IsValid || employeeModel.Id == default) return BadRequest(ModelState);

            _logger.LogInformation($"Updating employee with ID: {employeeModel.Id}");

            var updatedEmployee = await _employeeRepository.UpdateEmployeeAsync(employeeModel);

            return Ok(updatedEmployee);
        }
    }
}
