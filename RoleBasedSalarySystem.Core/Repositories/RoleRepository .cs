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
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RoleRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Role> CreateRoleAsync(Role role)
        {
            role.CreatedDate = DateTime.Now;
            var newRole = await _dbContext.Roles.AddAsync(role);

            await _dbContext.SaveChangesAsync();

            return newRole.Entity;
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            try
            {
                var role = await _dbContext.Roles.FindAsync(id);

                if (role == null) return false;

                role.IsDeleted = true;
                role.LastModifiedDate = DateTime.Now;

                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Role> GetRoleByIdAsync(int id)
        {
            return await _dbContext.Roles
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<Role>> GetRolesAsync()
        {
            return await _dbContext.Roles
                .Where(x => !x.IsDeleted)
                .ToListAsync();
        }

        public async Task<Role> UpdateRoleAsync(Role role)
        {
            try
            {
                role.LastModifiedDate = DateTime.Now;

                var updatedRole = _dbContext.Update(role);

                await _dbContext.SaveChangesAsync();

                return updatedRole.Entity;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
