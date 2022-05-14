namespace RoleBasedSalarySystem.Core.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public decimal Rate { get; set; }
    }
}
