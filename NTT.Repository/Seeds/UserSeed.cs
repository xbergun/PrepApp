/*
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTT.Core.Entity;

namespace NTT.Repository.Seeds;

public class UserSeed : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasData(
            new ApplicationUser
            {
                Id = 1, 
                FirstName = "John", 
                LastName = "Doe",
                Username = "johndoe",
                Email = "johndoe@gmail.com",
                TcNo = "12345678901",
            },
        new ApplicationUser
            {
                Id = 2, 
                FirstName = "George", 
                LastName = "Bush",
                Username = "georgebush",
                Email = "georgebush@gmail.com",
                TcNo = "55345678901",
            },
        new ApplicationUser    
            {
                Id = 3, 
                FirstName = "Michael", 
                LastName = "Jackson",
                Username = "michaeljackson",
                Email = "michealjack@gmail.com",
                TcNo = "12345678901",
            }
        
            
        );
    }
}
*/