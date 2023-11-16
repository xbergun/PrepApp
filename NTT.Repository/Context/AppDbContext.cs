using System.Reflection;
using Microsoft.EntityFrameworkCore;
using NTT.Core.Entity;
using NTT.Repository.Context.Configuration;
using NTT.Repository.Seeds;

namespace NTT.Repository.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<User?> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<TelephoneNumber> TelephoneNumbers { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        modelBuilder.ApplyConfiguration(new TelephoneNumberConfiguration());
        modelBuilder.ApplyConfiguration(new UserSeed());
        modelBuilder.ApplyConfiguration(new UserRoleSeed());
        modelBuilder.ApplyConfiguration(new TelephoneNumberSeed());
    }
    
}