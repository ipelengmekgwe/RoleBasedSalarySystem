using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoleBasedSalarySystem.DataAccess.Entities;

namespace RoleBasedSalarySystem.DataAccess.Config
{
    public class WorkConfiguration : IEntityTypeConfiguration<Work>
    {
        public void Configure(EntityTypeBuilder<Work> builder)
        {
            builder.Property(p => p.CreatedDate).ValueGeneratedOnUpdate();
            builder.HasOne(e => e.Employee).WithMany().HasForeignKey(p => p.EmployeeId);
            builder.HasOne(t => t.Task).WithMany().HasForeignKey(p => p.TaskId);
        }
    }
}
