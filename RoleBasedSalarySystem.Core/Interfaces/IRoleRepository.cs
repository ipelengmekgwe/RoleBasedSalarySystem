using RoleBasedSalarySystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoleBasedSalarySystem.Core.Interfaces
{
    public interface IRoleRepository
    {
        public Task<RoleModel> GetRoleByIdAsync(int id);
        public Task<IReadOnlyList<RoleModel>> GetRolesAsync();
        public Task<RoleModel> CreateRoleAsync(RoleModel role);
        public Task<RoleModel> UpdateRoleAsync(RoleModel role);
        public Task<bool> DeleteRoleAsync(int id);
    }
}
