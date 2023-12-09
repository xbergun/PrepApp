using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NTT.Core.Configuration;
using NTT.Core.Entity;
using NTT.Core.Repositories;
using NTT.Core.UnitOfWorks;
using NTT.Repository.Context;
using NTT.Repository.Repositories;
using NTT.Repository.UnitOfWorks;
using NTT.Service.Abstractions;
using NTT.Service.Implementations.Independent;
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
        services.AddSwaggerGen();
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
    //TODO: scoped, transient, singleton
    private static IServiceCollection AddServiceCollections(this IServiceCollection services)
    {
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<ITokenService, TokenService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IBlogService, BlogService>();
        services.AddTransient<IPostService, PostService>();
        return services;
    }

    private static IServiceCollection Configure(this IServiceCollection services,IConfiguration configuration)
    {
        services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
        services.Configure<JwtConfig>(configuration.GetSection("Token"));
        services.Configure<IdentityOptions>(opt =>
        {
            opt.Password.RequireDigit = false;
            opt.Password.RequireLowercase = false;
            opt.Password.RequireUppercase = false;
            opt.Password.RequireNonAlphanumeric = false;
            opt.Password.RequiredLength = 3;
        });
        
        return services;
    } 
    
    private static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<ApplicationUser,ApplicationRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
            
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
    
    private static IServiceCollection AddSwaggerGen(this IServiceCollection services)
    {
        services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new OpenApiInfo{ Title = "MyAPI", Version = "v1" });
            opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "bearer"
            });

            opt.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        }
                    },
                    new string[]{}
                }
            });
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