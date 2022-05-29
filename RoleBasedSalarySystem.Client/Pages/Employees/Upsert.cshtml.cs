using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RoleBasedSalarySystem.Client.Services.Employee;
using RoleBasedSalarySystem.Client.Services.Image;
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
        private readonly IImageService _imageService;

        public UpsertModel(IEmployeeService employeeService, IRoleService roleService, IImageService imageService)
        {
            _employeeService = employeeService;
            _roleService = roleService;
            _imageService = imageService;
        }

        [BindProperty]
        public EmployeeModel Employee { get; set; }

        [BindProperty]
        public IEnumerable<RoleModel> Roles { get; set; }

        [BindProperty]
        public IFormFile ImageFile { get; set; }

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

                Employee.ProfilePictureUrl = await _imageService.UploadImage(ImageFile, Employee.IdNumber);

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
