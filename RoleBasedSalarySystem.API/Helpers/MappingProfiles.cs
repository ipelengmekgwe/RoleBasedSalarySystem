using AutoMapper;
using RoleBasedSalarySystem.DataAccess.Entities;
using RoleBasedSalarySystem.Models;

namespace RoleBasedSalarySystem.API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(x => x.ProfilePictureUrl, o => o.MapFrom<EmployeeUrlResolver>());
        }
    }
}
