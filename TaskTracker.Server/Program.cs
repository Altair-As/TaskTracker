using Microsoft.EntityFrameworkCore;
using TaskTracker.Server.Data;

var builder = WebApplication.CreateBuilder(args);

// Add MVC controllers
builder.Services.AddControllers();

// Add SwaggerUI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Database context
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString ?? 
        throw new InvalidOperationException("Connection string not found"));
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
