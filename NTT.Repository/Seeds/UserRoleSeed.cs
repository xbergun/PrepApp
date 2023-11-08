using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTT.Core.Entity;
using NTT.Core.Enum;

namespace NTT.Repository.Seeds;

public class UserRoleSeed : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasData(
            new UserRole
            {
                Id = 1,
                UserId = 1,
                RoleType = UserRoleEnum.User.ToString()
            },
            new UserRole
            {
                Id = 2,
                UserId = 1,
                RoleType = UserRoleEnum.Admin.ToString()
            },
            new UserRole
            {
                Id = 3,
                UserId = 2,
                RoleType = UserRoleEnum.Admin.ToString()
            },
            new UserRole
            {
                Id = 4,
                UserId = 3,
                RoleType = UserRoleEnum.Guest.ToString()
            }
        );
    }
}