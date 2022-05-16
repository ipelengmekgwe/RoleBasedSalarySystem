using RoleBasedSalarySystem.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoleBasedSalarySystem.Core.Interfaces
{
    public interface IRoleRepository
    {
        public Task<Role> GetRoleByIdAsync(int id);
        public Task<IReadOnlyList<Role>> GetRolesAsync();
        public Task<Role> CreateRoleAsync(Role role);
        public Task<Role> UpdateRoleAsync(Role role);
        public Task<bool> DeleteRoleAsync(int id);
    }
}
