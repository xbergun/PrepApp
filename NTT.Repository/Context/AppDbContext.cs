using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NTT.Core.Entity;
using NTT.Repository.Seeds;

namespace NTT.Repository.Context;

public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid,
    IdentityUserClaim<Guid>, ApplicationUserRole, IdentityUserLogin<Guid>,
    IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public virtual DbSet<ApplicationRefreshToken> ApplicationRefreshTokens { get; set; } = null!;
    public virtual DbSet<TelephoneNumber> TelephoneNumbers { get; set; } = null!;
    
    /*
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        modelBuilder.ApplyConfiguration(new TelephoneNumberConfiguration());
        modelBuilder.ApplyConfiguration(new UserSeed());
        modelBuilder.ApplyConfiguration(new UserRoleSeed());
        modelBuilder.ApplyConfiguration(new TelephoneNumberSeed());
    }
    */
}