using System;
using System.Collections.Generic;
using System.Text;

namespace RoleBasedSalarySystem.Core.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public Role Role { get; set; }
    }
}
