using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RoleBasedSalarySystem.Client.Services.Employee;
using RoleBasedSalarySystem.Client.Services.Role;
using RoleBasedSalarySystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoleBasedSalarySystem.Client.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly IEmployeeService _employeeService;
        private readonly IRoleService _roleService;

        public CreateModel(IEmployeeService employeeService, IRoleService roleService)
        {
            _employeeService = employeeService;
            _roleService = roleService;
        }

        [BindProperty]
        public EmployeeDto Employee { get; set; }

        //[BindProperty]
        public IEnumerable<RoleDto> Roles { get; set; } 

        public async Task OnGetAsync()
        {
            Roles = await _roleService.GetRolesAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var success = await _employeeService.CreateEmployeeAsync(Employee);

                if (success)
                    return RedirectToAction("Index");
                else
                    return Page();
            }
            else
            {
                return Page();
            }
        }
    }
}
