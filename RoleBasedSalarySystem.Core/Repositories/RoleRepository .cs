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
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public RoleRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<RoleModel> CreateRoleAsync(RoleModel roleModel)
        {
            var role = _mapper.Map<RoleModel, Role>(roleModel);
            role.CreatedDate = DateTime.Now;

            var newRole = await _dbContext.Roles.AddAsync(role);

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<Role, RoleModel>(newRole.Entity);
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

        public async Task<RoleModel> GetRoleByIdAsync(int id)
        {
            var role = await _dbContext.Roles
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<Role, RoleModel>(role);
        }

        public async Task<IReadOnlyList<RoleModel>> GetRolesAsync()
        {
            var roles = await _dbContext.Roles
                .Where(x => !x.IsDeleted)
                .ToListAsync();

            return _mapper.Map<IReadOnlyList<Role>, IReadOnlyList<RoleModel>>(roles);
        }

        public async Task<RoleModel> UpdateRoleAsync(RoleModel roleModel)
        {
            try
            {
                var role = _mapper.Map<RoleModel, Role>(roleModel);
                role.LastModifiedDate = DateTime.Now;

                var updatedRole = _dbContext.Update(role);

                await _dbContext.SaveChangesAsync();

                return _mapper.Map<Role, RoleModel>(updatedRole.Entity);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
