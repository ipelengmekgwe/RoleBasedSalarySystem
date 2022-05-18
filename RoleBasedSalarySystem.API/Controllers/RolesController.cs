using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RoleBasedSalarySystem.Core.Interfaces;
using RoleBasedSalarySystem.Models;
using System.Threading.Tasks;

namespace RoleBasedSalarySystem.API.Controllers
{
    public class RolesController : BaseApiController
    {
        private readonly ILogger<RolesController> _logger;
        private readonly IRoleRepository _roleRepository;

        public RolesController(ILogger<RolesController> logger, IRoleRepository roleRepository)
        {
            _logger = logger;
            _roleRepository = roleRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRole(int id)
        {
            _logger.LogInformation($"Getting role with ID: {id}");

            var role = await _roleRepository.GetRoleByIdAsync(id);

            if (role == null) return NotFound();

            return Ok(role);
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            _logger.LogInformation($"Getting all roles");

            var roles = await _roleRepository.GetRolesAsync();

            return Ok(roles);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateRole([FromBody] RoleModel roleModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _logger.LogInformation($"Creating new role");

            var role = await _roleRepository.CreateRoleAsync(roleModel);

            return Ok(role);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            _logger.LogInformation($"Deleting role with ID: {id}");

            var deleted = await _roleRepository.DeleteRoleAsync(id);

            return Ok(deleted);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateRole([FromBody] RoleModel roleModel)
        {
            if (!ModelState.IsValid || roleModel.Id == default) return BadRequest(ModelState);

            _logger.LogInformation($"Updating role with ID: {roleModel.Id}");

            var updatedRole = await _roleRepository.UpdateRoleAsync(roleModel);

            return Ok(updatedRole);
        }
    }
}
