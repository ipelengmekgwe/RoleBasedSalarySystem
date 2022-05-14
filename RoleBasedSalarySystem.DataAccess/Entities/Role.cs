namespace RoleBasedSalarySystem.DataAccess.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public decimal Rate { get; set; }
    }
}
