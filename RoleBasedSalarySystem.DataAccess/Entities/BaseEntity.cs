using System;

namespace RoleBasedSalarySystem.DataAccess.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int? LastModifiedById { get; set; } // this will be the user id
    }
}
