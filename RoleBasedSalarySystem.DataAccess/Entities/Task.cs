using System;

namespace RoleBasedSalarySystem.DataAccess.Entities
{
    public class Task : BaseEntity
    {
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
