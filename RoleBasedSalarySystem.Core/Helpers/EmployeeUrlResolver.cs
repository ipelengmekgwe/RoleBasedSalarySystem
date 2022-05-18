using AutoMapper;
using Microsoft.Extensions.Configuration;
using RoleBasedSalarySystem.DataAccess.Entities;
using RoleBasedSalarySystem.Models;

namespace RoleBasedSalarySystem.Core.Helpers
{
    public class EmployeeUrlResolver : IValueResolver<Employee, EmployeeModel, string>
    {
        private readonly IConfiguration _config;

        public EmployeeUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Employee source, EmployeeModel destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ProfilePictureUrl))
            {
                return _config["ApiUrl"] + source.ProfilePictureUrl;
            }

            return null;
        }
    }
}
