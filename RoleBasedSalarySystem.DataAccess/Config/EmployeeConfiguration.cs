using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoleBasedSalarySystem.DataAccess.Entities;

namespace RoleBasedSalarySystem.DataAccess.Config
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(255);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(255);
            builder.Property(p => p.IdNumber).IsRequired().HasMaxLength(255);
            builder.HasIndex(p => p.IdNumber).IsUnique();
            builder.Property(p => p.ProfilePictureUrl).HasMaxLength(255);
            builder.HasOne(r => r.Role).WithMany().HasForeignKey(p => p.RoleId);
        }
    }
}
