using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NTT.Core.Configuration;
using NTT.Core.Repositories;
using NTT.Core.UnitOfWorks;
using NTT.Repository.Context;
using NTT.Repository.Repositories;
using NTT.Repository.UnitOfWorks;
using NTT.Service.Abstractions;
using NTT.Service.Services;

namespace NTT.API.Utilities;

public static class Bootstrapper
{
    
    public static void AddBootstrapper(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddServiceCollections();
        services.AddDbContext(configuration);
        services.Configure(configuration);
        services.AddAuthentication(configuration);
    }
    
    private static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(db =>
            db.UseSqlServer(configuration.GetConnectionString("SqlConnection"), option =>
            {
                option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext))?.GetName().Name);
            })
        );
        return services;
    }
    
    private static IServiceCollection AddServiceCollections(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenService, TokenService>();
        //services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        //services.AddScoped<IUserWithTelephoneNumbersRepository, UserWithTelephoneNumbersRepository>();
        services.AddScoped<IUserService, UserService>();
        
        //services.AddScoped<IUserRoleService, UserRoleService>();

        return services;
    }

    private static IServiceCollection Configure(this IServiceCollection services,IConfiguration configuration)
    {
        services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
        services.Configure<JwtConfig>(configuration.GetSection("Token"));
        return services;
    } 
    
    private static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ValidIssuer = configuration["Token:Issuer"],
                ValidAudience = configuration["Token:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"] ?? string.Empty)),
                ClockSkew = TimeSpan.Zero
            };
        });
        return services;
    }
    
    
    /*
    private static IServiceCollection AddControllers(this IServiceCollection services)
    {
        services.AddControllers(options =>  options.Filters.Add(new ValidateFilterAttribute())).AddFluentValidation(x=>x.RegisterValidatorsFromAssemblyContaining<UserDtoValidator>());
    }
    */
    
   
    
}