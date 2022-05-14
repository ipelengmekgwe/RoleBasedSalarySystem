using System;

namespace RoleBasedSalarySystem.Core.Entities
{
    public class Work
    {
        public int EmployeeId { get; set; }
        public DateTime DateOfWork { get; set; }
        public int TaskId { get; set; }
    }
}
