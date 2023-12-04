/*
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTT.Core.Entity;

namespace NTT.Repository.Context.Configuration;

public class UserRoleConfiguration : IEntityTypeConfiguration<ApplicationUserRole>
{
    public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
    {
        builder.HasKey(ur => ur.Id);
        builder.Property(ur => ur.Id).UseIdentityColumn(); //1,1 auto increment

        builder.HasOne(ur => ur.ApplicationUser).WithMany(ur => ur.UserRoles).HasForeignKey(u => u.UserId).IsRequired();
    }
}
*/