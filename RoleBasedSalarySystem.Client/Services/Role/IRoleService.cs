using RoleBasedSalarySystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoleBasedSalarySystem.Client.Services.Role
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleModel>> GetRolesAsync();
        Task<bool> CreateRoleAsync(RoleModel role);
    }
}
