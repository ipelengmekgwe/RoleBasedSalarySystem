using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RoleBasedSalarySystem.Client.Services.Employee;
using RoleBasedSalarySystem.Client.Services.Role;
using RoleBasedSalarySystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoleBasedSalarySystem.Client.Pages.Employees
{
    public class UpsertModel : PageModel
    {
        private readonly IEmployeeService _employeeService;
        private readonly IRoleService _roleService;

        public UpsertModel(IEmployeeService employeeService, IRoleService roleService)
        {
            _employeeService = employeeService;
            _roleService = roleService;
        }

        [BindProperty]
        public EmployeeModel Employee { get; set; }

        [BindProperty]
        public IEnumerable<RoleModel> Roles { get; set; }

        public async Task OnGetAsync(int? id)
        {
            Roles = await _roleService.GetRolesAsync();

            if (id.HasValue)
            {
                Employee = await _employeeService.GetEmployeeByIdAsync(id.Value);
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                bool success;
                if (Employee.Id == 0)
                {
                    success = await _employeeService.CreateEmployeeAsync(Employee);
                }
                else
                {
                    success = await _employeeService.UpdateEmployeeAsync(Employee);
                }

                if (success)
                    return RedirectToPage("Index");
            }

            if (!Roles.Any())
                Roles = await _roleService.GetRolesAsync();

            return Page();
        }
    }
}
