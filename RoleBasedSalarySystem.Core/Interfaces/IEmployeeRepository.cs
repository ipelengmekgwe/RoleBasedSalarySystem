using RoleBasedSalarySystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoleBasedSalarySystem.Core.Interfaces
{
    public interface IEmployeeRepository
    {
        public Task<EmployeeModel> GetEmployeeByIdAsync(int id);
        public Task<IReadOnlyList<EmployeeModel>> GetEmployeesAsync();
        public Task<EmployeeModel> CreateEmployeeAsync(EmployeeModel employee);
        public Task<EmployeeModel> UpdateEmployeeAsync(EmployeeModel employee);
        public Task<bool> DeleteEmployeeAsync(int id);
    }
}
