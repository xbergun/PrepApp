using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTT.Core.Entity;

namespace NTT.Repository.Context.Configuration;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(ur => ur.Id);
        builder.Property(ur => ur.Id).UseIdentityColumn(); //1,1 auto increment
        builder.Property(ur => ur.RoleType).IsRequired().HasMaxLength(50);

        builder.HasOne(ur => ur.User).WithMany(ur => ur.UserRoles).HasForeignKey(u => u.UserId).IsRequired();
    }
}