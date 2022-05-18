using Microsoft.Extensions.Logging;
using RoleBasedSalarySystem.Client.Helpers;
using RoleBasedSalarySystem.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RoleBasedSalarySystem.Client.Services.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ILogger<EmployeeService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public EmployeeService(IHttpClientFactory httpClientFactory, ILogger<EmployeeService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<bool> CreateEmployeeAsync(EmployeeModel employee)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("RBSS.API");
                var response = await httpClient.PostAsJsonAsync("employees/create", employee);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encounter while creating an employee. Message: {ex.InnerException.Message ?? ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("RBSS.API");
                var response = await httpClient.DeleteAsync($"employees/{id}");

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encounter while deleting an employee. Message: {ex.InnerException.Message ?? ex.Message}");
                return false;
            }
        }

        public async Task<EmployeeModel> GetEmployeeByIdAsync(int id)
        {
            var employee = new EmployeeModel();
            try
            {
                var httpClient = _httpClientFactory.CreateClient("RBSS.API");
                var response = await httpClient.GetAsync($"employees/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    employee = JsonHelper<EmployeeModel>.Deserialize(result);
                }

                return employee;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encounter while fetching an employee. Message: {ex.InnerException.Message ?? ex.Message}");
                return employee;
            }
        }

        public async Task<IEnumerable<EmployeeModel>> GetEmployeesAsync()
        {
            var employees = new List<EmployeeModel>();
            try
            {
                var httpClient = _httpClientFactory.CreateClient("RBSS.API");
                var response = await httpClient.GetAsync("employees");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    employees = JsonHelper<List<EmployeeModel>>.Deserialize(result);
                }

                return employees;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encounter while fetching list of employees. Message: {ex.InnerException.Message ?? ex.Message}");
                return employees;
            }

        }

        public async Task<bool> UpdateEmployeeAsync(EmployeeModel employee)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("RBSS.API");
                var response = await httpClient.PostAsJsonAsync("employees/update", employee);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encounter while creating an employee. Message: {ex.InnerException.Message ?? ex.Message}");
                return false;
            }
        }
    }
}
