using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoleBasedSalarySystem.DataAccess.Entities;

namespace RoleBasedSalarySystem.DataAccess.Config
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.CreatedDate).ValueGeneratedOnUpdate();
            builder.Property(p => p.UserName).HasMaxLength(255);
            builder.Property(p => p.Password).HasMaxLength(500);
        }
    }
}
