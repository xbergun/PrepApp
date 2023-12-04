
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTT.Core.Entity;
/*
namespace NTT.Repository.Context.Configuration;

public class TelephoneNumberConfiguration : IEntityTypeConfiguration<TelephoneNumber>
{
    public void Configure(EntityTypeBuilder<TelephoneNumber> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).UseIdentityColumn(); //1,1 auto increment
        
        builder.HasOne(t => t.ApplicationUser).WithMany(t => t.TelephoneNumbers).HasForeignKey(t => t.UserId).IsRequired();
    }
}
*/