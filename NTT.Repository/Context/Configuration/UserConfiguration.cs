using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTT.Core.Entity;

namespace NTT.Repository.Context.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).UseIdentityColumn(); //1,1 auto increment
        builder.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(u => u.LastName).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Username).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(50);
        builder.Property(u => u.TcNo).IsRequired().HasMaxLength(11);
        
    builder.HasMany(u => u.UserRoles).WithOne(u=>u.User).HasForeignKey(u=>u.Id);
    builder.HasMany(u => u.TelephoneNumbers).WithOne(u=>u.User).HasForeignKey(u=>u.Id);
        
    }
}