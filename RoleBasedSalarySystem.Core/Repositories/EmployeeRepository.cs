using Microsoft.EntityFrameworkCore;
using RoleBasedSalarySystem.Core.Interfaces;
using RoleBasedSalarySystem.DataAccess.Data;
using RoleBasedSalarySystem.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoleBasedSalarySystem.Core.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            employee.CreatedDate = DateTime.Now;
            var newEmployee = await _dbContext.Employees.AddAsync(employee);

            await _dbContext.SaveChangesAsync();

            return newEmployee.Entity;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            try
            {
                var employee = await _dbContext.Employees.FindAsync(id);

                if (employee == null) return false;

                employee.IsDeleted = true;
                employee.LastModifiedDate = DateTime.Now;
                //employee.LastModifiedById = 1; // from identityUserService once implemented

                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _dbContext.Employees
                .Where(x => !x.IsDeleted)
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<Employee>> GetEmployeesAsync()
        {
            return await _dbContext.Employees
                .Where(x => !x.IsDeleted)
                .Include(x => x.Role)
                .ToListAsync();
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            try
            {
                employee.LastModifiedDate = DateTime.Now;
                //employee.LastModifiedById = 1; // from identityUserService once implemented

                var updatedEmployee = _dbContext.Update(employee);

                await _dbContext.SaveChangesAsync();

                return updatedEmployee.Entity;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
