using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoleBasedSalarySystem.DataAccess.Entities;

namespace RoleBasedSalarySystem.DataAccess.Config
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(p => p.CreatedDate).ValueGeneratedOnUpdate();
            builder.Property(p => p.Name).HasMaxLength(255);
            builder.Property(p => p.Rate).HasColumnType("decimal(18,2)");
        }
    }
}
