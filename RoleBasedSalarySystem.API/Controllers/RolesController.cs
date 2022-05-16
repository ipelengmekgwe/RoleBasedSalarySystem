using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RoleBasedSalarySystem.Core.Interfaces;
using RoleBasedSalarySystem.DataAccess.Entities;
using RoleBasedSalarySystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoleBasedSalarySystem.API.Controllers
{
    public class RolesController : BaseApiController
    {
        private readonly ILogger<RolesController> _logger;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RolesController(ILogger<RolesController> logger, IRoleRepository roleRepository, IMapper mapper)
        {
            _logger = logger;
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRole(int id)
        {
            _logger.LogInformation($"Getting role with ID: {id}");
            var role = await _roleRepository.GetRoleByIdAsync(id);

            if (role == null) return NotFound();

            return Ok(_mapper.Map<Role, RoleDto>(role));
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            _logger.LogInformation($"Getting all roles");
            var roles = await _roleRepository.GetRolesAsync();

            return Ok(_mapper.Map<IReadOnlyList<Role>, IReadOnlyList<RoleDto>>(roles));
        }
    }
}
