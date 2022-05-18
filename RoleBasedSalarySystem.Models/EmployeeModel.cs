using System;
using System.ComponentModel.DataAnnotations;

namespace RoleBasedSalarySystem.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Date of Birth is required.")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "ID Number is required.")]
        public string IdNumber { get; set; }
        public string ProfilePictureUrl { get; set; }
        [Required(ErrorMessage = "Role is required.")]
        public int RoleId { get; set; }
    }
}
