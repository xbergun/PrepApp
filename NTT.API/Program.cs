// Repository => Data Access Layer, Generic Repository Pattern => Migrations, Seeds, Repository imp, UnitOfWork imp
// Service => Business Logic Layer, Generic Service Pattern => Mapping, Service imp, Validation, Exception Handling
// Core => Common Layer, Dto's, Entities, Interfaces
// API => Presentation Layer

using System.Reflection;
using Microsoft.EntityFrameworkCore;
using NTT.Core.Repositories;
using NTT.Core.Services;
using NTT.Core.UnitOfWorks;
using NTT.Repository.Context;
using NTT.Repository.Repositories;
using NTT.Repository.UnitOfWorks;
using NTT.Service.Mapping;
using NTT.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));

builder.Services.AddScoped<IUserWithUserRolesRepository, UserWithUserRolesRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddDbContext<AppDbContext>(db =>
    db.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext))?.GetName().Name);
    })
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

