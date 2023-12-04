/*
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTT.Core.Entity;
using NTT.Core.Enum;

namespace NTT.Repository.Seeds;

public class UserRoleSeed : IEntityTypeConfiguration<ApplicationUserRole>
{
    public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
    {
        builder.HasData(
            new ApplicationUserRole
            {
                Id = 1,
                UserId = 1,
                RoleType = UserRoleEnum.User.ToString()
            },
            new ApplicationUserRole
            {
                Id = 2,
                UserId = 1,
                RoleType = UserRoleEnum.Admin.ToString()
            },
            new ApplicationUserRole
            {
                Id = 3,
                UserId = 2,
                RoleType = UserRoleEnum.Admin.ToString()
            },
            new ApplicationUserRole
            {
                Id = 4,
                UserId = 3,
                RoleType = UserRoleEnum.Guest.ToString()
            }
        );
    }
}
*/