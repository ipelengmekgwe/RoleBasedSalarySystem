using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RoleBasedSalarySystem.Client.Services.Employee;
using RoleBasedSalarySystem.Models;
using System.Threading.Tasks;

namespace RoleBasedSalarySystem.Client.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly IEmployeeService _employeeService;

        public CreateModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [BindProperty]
        public EmployeeDto Employee { get; set; }

        public void OnGet()
        {
            // load the roles
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
