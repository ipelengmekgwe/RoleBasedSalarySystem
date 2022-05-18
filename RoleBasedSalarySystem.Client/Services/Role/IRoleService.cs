using RoleBasedSalarySystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoleBasedSalarySystem.Client.Services.Role
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleModel>> GetRolesAsync();
        Task<bool> CreateRoleAsync(RoleModel role);
        Task<RoleModel> GetRoleByIdAsync(int id);
        Task<bool> UpdateRoleAsync(RoleModel role);
        Task<bool> DeleteRole(int id);
    }
}
