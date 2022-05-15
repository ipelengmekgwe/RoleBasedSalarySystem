using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RoleBasedSalarySystem.Core.Interfaces;
using RoleBasedSalarySystem.DataAccess.Entities;
using RoleBasedSalarySystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoleBasedSalarySystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;


        public EmployeesController(ILogger<EmployeesController> logger, IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            _logger.LogInformation($"Getting employee with ID: {id}");
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);

            if (employee == null) return NotFound();

            return Ok(_mapper.Map<Employee, EmployeeDto>(employee));
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            _logger.LogInformation($"Getting all employees");
            var employees = await _employeeRepository.GetEmployeesAsync();

            return Ok(_mapper.Map<IReadOnlyList<Employee>, IReadOnlyList<EmployeeDto>>(employees));
        }
    }
}
