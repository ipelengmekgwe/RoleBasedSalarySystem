using System;

namespace RoleBasedSalarySystem.Core.Entities
{
    public class Task : BaseEntity
    {
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
