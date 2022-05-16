using Microsoft.EntityFrameworkCore;
using RoleBasedSalarySystem.DataAccess.Data;
using System;

namespace RoleBasedSalarySystem.Test.Helpers
{
    public static class DbHelper
    {
        public static ApplicationDbContext InitializeDb(string dbName = default)
        {
            if (dbName == null) dbName = Guid.NewGuid().ToString();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(dbName).Options;

            return new ApplicationDbContext(options);
        }
    }
}
