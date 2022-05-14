using System;
using System.Collections.Generic;
using System.Text;

namespace RoleBasedSalarySystem.DataAccess.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
