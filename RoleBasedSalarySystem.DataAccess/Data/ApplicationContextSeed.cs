using Microsoft.Extensions.Logging;
using RoleBasedSalarySystem.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using SystemTask = System.Threading.Tasks;

namespace RoleBasedSalarySystem.DataAccess.Data
{
    public class ApplicationContextSeed
    {
        public static async SystemTask.Task SeedAsync(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Roles.Any())
                {
                    var rolesData = File.ReadAllText("../RoleBasedSalarySystem.DataAccess/Data/SeedData/roles.json");

                    var roles = JsonSerializer.Deserialize<List<Role>>(rolesData);

                    foreach (var role in roles)
                    {
                        role.CreatedDate = DateTime.Now;
                        context.Roles.Add(role);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Employees.Any())
                {
                    var employeesData = File.ReadAllText("../RoleBasedSalarySystem.DataAccess/Data/SeedData/employees.json");

                    var employees = JsonSerializer.Deserialize<List<Employee>>(employeesData);

                    foreach (var employee in employees)
                    {
                        employee.CreatedDate = DateTime.Now;
                        context.Employees.Add(employee);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            { 
                var logger = loggerFactory.CreateLogger<ApplicationContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
