using Microsoft.Extensions.Logging;
using RoleBasedSalarySystem.Client.Helpers;
using RoleBasedSalarySystem.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RoleBasedSalarySystem.Client.Services.Role
{
    public class RoleService : IRoleService
    {
        private readonly ILogger<RoleService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public RoleService(IHttpClientFactory httpClientFactory, ILogger<RoleService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<bool> CreateRoleAsync(RoleModel role)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("RBSS.API");
                var response = await httpClient.PostAsJsonAsync("roles/create", role);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encounter while creating a role. Message: {ex.InnerException.Message ?? ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteRole(int id)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("RBSS.API");
                var response = await httpClient.DeleteAsync($"roles/{id}");

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encounter while deleting a role. Message: {ex.InnerException.Message ?? ex.Message}");
                return false;
            }
        }

        public async Task<RoleModel> GetRoleByIdAsync(int id)
        {
            var role = new RoleModel();
            try
            {
                var httpClient = _httpClientFactory.CreateClient("RBSS.API");
                var response = await httpClient.GetAsync($"roles/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    role = JsonHelper<RoleModel>.Deserialize(result);
                }

                return role;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encounter while fetching a role. Message: {ex.InnerException.Message ?? ex.Message}");
                return role;
            }
        }

        public async Task<IEnumerable<RoleModel>> GetRolesAsync()
        {
            var roles = new List<RoleModel>();
            try
            {
                var httpClient = _httpClientFactory.CreateClient("RBSS.API");
                var response = await httpClient.GetAsync("roles");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    roles = JsonHelper<List<RoleModel>>.Deserialize(result);
                }

                return roles;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encounter while fetching list of roles. Message: {ex.InnerException.Message ?? ex.Message}");
                return roles;
            }
        }

        public async Task<bool> UpdateRoleAsync(RoleModel role)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("RBSS.API");
                var response = await httpClient.PostAsJsonAsync("roles/update", role);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encounter while updating a role. Message: {ex.InnerException.Message ?? ex.Message}");
                return false;
            }
        }
    }
}
