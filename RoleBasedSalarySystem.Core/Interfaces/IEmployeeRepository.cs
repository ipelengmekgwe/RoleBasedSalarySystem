using RoleBasedSalarySystem.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoleBasedSalarySystem.Core.Interfaces
{
    public interface IEmployeeRepository
    {
        public Task<Employee> GetEmployeeByIdAsync(int id);
        public Task<IReadOnlyList<Employee>> GetEmployeesAsync();
        public Task<Employee> CreateEmployeeAsync(Employee employee);
        public Task<Employee> UpdateEmployeeAsync(Employee employee);
        public Task<bool> DeleteEmployeeAsync(int id);
    }
}
