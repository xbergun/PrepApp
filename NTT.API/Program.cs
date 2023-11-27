using NTT.API.Utilities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServiceCollections();

//builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddDbContext(builder.Configuration);

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