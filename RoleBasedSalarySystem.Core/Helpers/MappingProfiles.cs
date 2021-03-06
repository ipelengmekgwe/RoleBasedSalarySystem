using AutoMapper;
using RoleBasedSalarySystem.DataAccess.Entities;
using RoleBasedSalarySystem.Models;

namespace RoleBasedSalarySystem.Core.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, EmployeeModel>()
                .ForMember(x => x.ProfilePictureUrl, o => o.MapFrom<EmployeeUrlResolver>())
                .ReverseMap();

            CreateMap<Role, RoleModel>().ReverseMap();
        }
    }
}
