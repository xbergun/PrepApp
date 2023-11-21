using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NTT.API.Filters;
using NTT.Core.Repositories;
using NTT.Core.Services;
using NTT.Core.UnitOfWorks;
using NTT.Repository.Context;
using NTT.Repository.Repositories;
using NTT.Repository.UnitOfWorks;
using NTT.Service.Abstractions;
using NTT.Service.Implementations;
using NTT.Service.Services;
using NTT.Service.Validations;

namespace NTT.API.Utilities;

public static class Bootstrapper
{
    
    public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(db =>
            db.UseSqlServer(configuration.GetConnectionString("SqlConnection"), option =>
            {
                option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext))?.GetName().Name);
            })
        );
        return services;
    }
    
    public static IServiceCollection AddServiceCollections(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        services.AddScoped<IUserWithTelephoneNumbersRepository, UserWithTelephoneNumbersRepository>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserRoleService, UserRoleService>();

        return services;
    }

    public static IServiceCollection Configure(this IServiceCollection services)
    {
        //TODO: Arastir.
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });
        
        services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
        
        return services;
    } 
    /*
    public static IServiceCollection AddControllers(this IServiceCollection services)
    {
        services.AddControllers(options =>  options.Filters.Add(new ValidateFilterAttribute())).AddFluentValidation(x=>x.RegisterValidatorsFromAssemblyContaining<UserDtoValidator>());
    }
    */
    
}