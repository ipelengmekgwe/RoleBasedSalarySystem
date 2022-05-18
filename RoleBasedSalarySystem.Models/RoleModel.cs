using System.ComponentModel.DataAnnotations;

namespace RoleBasedSalarySystem.Models
{
    public class RoleModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Rate is required.")]
        public decimal Rate { get; set; }
    }
}
