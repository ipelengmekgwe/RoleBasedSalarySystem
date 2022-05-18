using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RoleBasedSalarySystem.Client.Services.Role;
using RoleBasedSalarySystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoleBasedSalarySystem.Client.Pages.Roles
{
    public class IndexModel : PageModel
    {
        private readonly IRoleService _roleService;

        public IndexModel(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public IEnumerable<RoleModel> Roles { get; set; }

        public async Task OnGetAsync()
        {
            Roles = await _roleService.GetRolesAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var deleted = await _roleService.DeleteRole(id);

            if (deleted)
                return RedirectToPage("Index");

            return NotFound();
        }
    }
}
