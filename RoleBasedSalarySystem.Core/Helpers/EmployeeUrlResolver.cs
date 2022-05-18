using AutoMapper;
using Microsoft.Extensions.Configuration;
using RoleBasedSalarySystem.DataAccess.Entities;
using RoleBasedSalarySystem.Models;
using System.Linq;

namespace RoleBasedSalarySystem.Core.Helpers
{
    public class EmployeeUrlResolver : IValueResolver<Employee, EmployeeModel, string>, IValueResolver<EmployeeModel, Employee, string>
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

        public string Resolve(EmployeeModel source, Employee destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ProfilePictureUrl))
            {
                var extension = source.ProfilePictureUrl.Split('.').Last();
                var fullName = $"{source.FirstName.ToLowerInvariant()}-{source.LastName.ToLowerInvariant()}";
                return $"images/{fullName}.{extension}";
            }

            return null;
        }
    }
}
