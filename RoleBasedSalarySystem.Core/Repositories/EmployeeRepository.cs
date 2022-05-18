using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RoleBasedSalarySystem.Core.Interfaces;
using RoleBasedSalarySystem.DataAccess.Data;
using RoleBasedSalarySystem.DataAccess.Entities;
using RoleBasedSalarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoleBasedSalarySystem.Core.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public EmployeeRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<EmployeeModel> CreateEmployeeAsync(EmployeeModel employeeModel)
        {
            var employee = _mapper.Map<EmployeeModel, Employee>(employeeModel);
            employee.CreatedDate = DateTime.Now;

            var newEmployee = await _dbContext.Employees.AddAsync(employee);

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<Employee, EmployeeModel>(newEmployee.Entity);
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            try
            {
                var employee = await _dbContext.Employees.FindAsync(id);

                if (employee == null) return false;

                employee.IsDeleted = true;
                employee.LastModifiedDate = DateTime.Now;

                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<EmployeeModel> GetEmployeeByIdAsync(int id)
        {
            var employee = await _dbContext.Employees
                .Where(x => !x.IsDeleted)
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<Employee, EmployeeModel>(employee);
        }

        public async Task<IReadOnlyList<EmployeeModel>> GetEmployeesAsync()
        {
            var employees = await _dbContext.Employees
                .Where(x => !x.IsDeleted)
                .Include(x => x.Role)
                .ToListAsync();

            return _mapper.Map<IReadOnlyList<Employee>, IReadOnlyList<EmployeeModel>>(employees);
        }

        public async Task<EmployeeModel> UpdateEmployeeAsync(EmployeeModel employeeModel)
        {
            try
            {
                var employee = _mapper.Map<EmployeeModel, Employee>(employeeModel);
                employee.LastModifiedDate = DateTime.Now;

                var updatedEmployee = _dbContext.Update(employee);

                await _dbContext.SaveChangesAsync();

                return _mapper.Map<Employee, EmployeeModel>(updatedEmployee.Entity);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
