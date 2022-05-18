using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RoleBasedSalarySystem.Client.Services.Employee;
using RoleBasedSalarySystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoleBasedSalarySystem.Client.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly IEmployeeService _employeeService;

        public IndexModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IEnumerable<EmployeeModel> Employees { get; set; }

        public async Task OnGetAsync()
        {
            Employees = await _employeeService.GetEmployeesAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var deleted = await _employeeService.DeleteEmployee(id);

            if (deleted)
                return RedirectToPage("Index");

            return NotFound();
        }
    }
}
