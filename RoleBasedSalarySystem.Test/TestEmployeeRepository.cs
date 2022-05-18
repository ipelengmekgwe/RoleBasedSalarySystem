using AutoMapper;
using Moq;
using RoleBasedSalarySystem.Core.Repositories;
using RoleBasedSalarySystem.DataAccess.Data;
using RoleBasedSalarySystem.DataAccess.Entities;
using RoleBasedSalarySystem.Models;
using RoleBasedSalarySystem.Test.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace RoleBasedSalarySystem.Test
{
    public class TestEmployeeRepository
    {
        private Mock<IMapper> _mapper;

        [Fact]
        public async void EmployeeRepository_GetAllEmployees_If_Exists()
        {
            // Arrange
            _mapper = CreateMapper();
            using var dbContext = DbHelper.InitializeDb();

            var sut = new EmployeeRepository(dbContext, _mapper.Object);

            var role = await CreateRole(dbContext);
            await sut.CreateEmployeeAsync(new EmployeeModel { Id = 1, RoleId = role.Id });
            await sut.CreateEmployeeAsync(new EmployeeModel { Id = 2, RoleId = role.Id });

            // Act
            var allEmployees = await sut.GetEmployeesAsync();

            // Assert
            Assert.Equal(2, allEmployees.Count);
        }

        private async Task<Role> CreateRole(ApplicationDbContext dbContext)
        {
            var role = new Role { Id = 1 };
            dbContext.Roles.Add(role);
            await dbContext.SaveChangesAsync();

            return role;
        }

        private Mock<IMapper> CreateMapper()
        {
            _mapper = new Mock<IMapper>();

            _mapper.Setup(m => m.Map<Employee, EmployeeModel>(It.IsAny<Employee>()))
                .Returns((Employee emp) => 
                {
                    return new EmployeeModel { Id = emp.Id, RoleId = emp.RoleId };
                });

            _mapper.Setup(m => m.Map<EmployeeModel, Employee>(It.IsAny<EmployeeModel>()))
                .Returns((EmployeeModel emp) => 
                {
                    return new Employee { Id = emp.Id, RoleId = emp.RoleId };
                });

            _mapper.Setup(m => m.Map<IReadOnlyList<Employee>, IReadOnlyList<EmployeeModel>>(It.IsAny<IReadOnlyList<Employee>>()))
                .Returns((IReadOnlyList<Employee> emps) =>
                {
                    var empModList = new List<EmployeeModel>();
                    foreach (var emp in emps)
                    {
                        empModList.Add(new EmployeeModel { Id = emp.Id, RoleId = emp.RoleId });
                    }

                    return empModList;
                });

            return _mapper;
        }
    }
}
