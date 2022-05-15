using System;

namespace RoleBasedSalarySystem.DataAccess.Entities
{
    public class Work : BaseEntity
    {
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public DateTime DateOfWork { get; set; }
        public Task Task { get; set; }
        public int TaskId { get; set; }
    }
}
