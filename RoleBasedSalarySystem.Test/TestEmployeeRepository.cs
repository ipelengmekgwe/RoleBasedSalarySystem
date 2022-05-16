using RoleBasedSalarySystem.Core.Repositories;
using RoleBasedSalarySystem.DataAccess.Data;
using RoleBasedSalarySystem.DataAccess.Entities;
using RoleBasedSalarySystem.Test.Helpers;
using System.Threading.Tasks;
using Xunit;

namespace RoleBasedSalarySystem.Test
{
    public class TestEmployeeRepository
    {
        [Fact]
        public async void EmployeeRepository_GetAllEmployees_If_Exists()
        {
            // Arrange
            using var dbContext = DbHelper.InitializeDb();

            var sut = new EmployeeRepository(dbContext);

            var role = await CreateRole(dbContext);
            await sut.CreateEmployeeAsync(new Employee { Id = 1, RoleId = role.Id });
            await sut.CreateEmployeeAsync(new Employee { Id = 2, RoleId = role.Id });

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
    }
}
