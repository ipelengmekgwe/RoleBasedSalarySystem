using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RoleBasedSalarySystem.Client.Services.Role;
using RoleBasedSalarySystem.Models;
using System.Threading.Tasks;

namespace RoleBasedSalarySystem.Client.Pages.Roles
{
    public class UpsertModel : PageModel
    {
        private readonly IRoleService _roleService;

        public UpsertModel(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [BindProperty]
        public RoleModel Role { get; set; }

        public async Task OnGetAsync(int? id)
        {
            if (id.HasValue)
            {
                Role = await _roleService.GetRoleByIdAsync(id.Value);
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                bool success;
                if (Role.Id == 0)
                {
                    success = await _roleService.CreateRoleAsync(Role);
                }
                else
                {
                    success = await _roleService.UpdateRoleAsync(Role);
                }

                if (success)
                    return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
