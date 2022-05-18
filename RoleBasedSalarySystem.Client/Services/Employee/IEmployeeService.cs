using RoleBasedSalarySystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoleBasedSalarySystem.Client.Services.Employee
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeModel>> GetEmployeesAsync();
        Task<bool> CreateEmployeeAsync(EmployeeModel employee);
        Task<EmployeeModel> GetEmployeeByIdAsync(int id);
        Task<bool> UpdateEmployeeAsync(EmployeeModel employee);
        Task<bool> DeleteEmployee(int id);
    }
}
