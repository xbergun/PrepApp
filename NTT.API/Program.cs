using Microsoft.OpenApi.Models;
using NTT.API.Utilities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBootstrapper(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

// TODO:  AspnetRoles, daha sonra userRole

//TODO: user managersiz sadece ef core ile yeni bir model + entity oluşturup onu kullanabilirsin.
//TODO: Microservices,
//TODO: N-Layer => Generic repository pattern + UnitOfWork pattern
//TODO: N-Layer => Generic repository pattern + abstract factory pattern
//TODO: N-Layer => Generic repository pattern + dao pattern
//TODO: N-Layer => Mediator pattern 
//TODO: N-Layer => CQRS pattern
//TODO: Singleton pattern
//TODO: SOLID + Clean Architecture

//TODO: Generic repository için reflection.
