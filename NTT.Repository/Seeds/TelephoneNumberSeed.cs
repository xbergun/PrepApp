using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTT.Core.Entity;

namespace NTT.Repository.Seeds;

public class TelephoneNumberSeed : IEntityTypeConfiguration<TelephoneNumber>
{
    public void Configure(EntityTypeBuilder<TelephoneNumber> builder)
    {
        builder.HasData(
            new TelephoneNumber
            {
                Id = 1,
                UserId = 1,
                TelNo = "05321234567"
            },
            new TelephoneNumber
            {
                Id = 2,
                UserId = 1,
                TelNo = "05321234568"
            },
            new TelephoneNumber
            {
                Id = 3,
                UserId = 2,
                TelNo = "05321234569"
            },
            new TelephoneNumber
            {
                Id = 4,
                UserId = 3,
                TelNo = "05321234570"
            }
        );
    }
}