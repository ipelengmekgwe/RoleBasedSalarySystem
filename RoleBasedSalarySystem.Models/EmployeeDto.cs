using System;

namespace RoleBasedSalarySystem.Models
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdNumber { get; set; }
        public string ProfilePictureUrl { get; set; }
        public int RoleId { get; set; }
    }
}
