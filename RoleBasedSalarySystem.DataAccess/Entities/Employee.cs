using System;

namespace RoleBasedSalarySystem.DataAccess.Entities
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdNumber { get; set; }
        public string ProfilePictureUrl { get; set; }
        public Role Role { get; set; }
    }
}
