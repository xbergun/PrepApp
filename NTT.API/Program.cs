// Repository => Data Access Layer, Generic Repository Pattern => Migrations, Seeds, Repository imp, UnitOfWork imp
// Service => Business Logic Layer, Generic Service Pattern => Mapping, Service imp, Validation, Exception Handling
// Core => Common Layer, Dto's, Entities, Interfaces
// API => Presentation Layer

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
using NTT.Service.Mapping;
using NTT.Service.Services;
using NTT.Service.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>  options.Filters.Add(new ValidateFilterAttribute())).AddFluentValidation(x=>x.RegisterValidatorsFromAssemblyContaining<UserDtoValidator>());

//TODO: Arastir.
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true); 



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//TODO: ADD Service collection in bootstrapper
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<IUserWithUserRolesRepository, UserWithUserRolesRepository>();
builder.Services.AddScoped<IUserWithUserRolesService, UserWithUserRolesService>();

builder.Services.AddScoped<IUserWithTelephoneNumbersRepository, UserWithTelephoneNumbersRepository>();
builder.Services.AddScoped<IUserWithTelephoneNumbersService, UserWithTelephoneNumbersService>();

// 20.11.2023
builder.Services.AddScoped<IUserService, UserService>();

//TODO: Auto Mapper kaldirilacak.
builder.Services.AddAutoMapper(typeof(MapProfile));

//TODO: Bootstrapper.
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

// TODO: Bootstrapper
//TODO: Service katmanı generic olmayacak. Sadece repository.
//TODO: Request ve response model.
