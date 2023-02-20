using HardCodeTest.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
services.AddControllers();
var appConfigBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
var appConfiguration = appConfigBuilder.Build();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:7119")
                          .AllowAnyHeader()
                          .AllowAnyMethod(); 
                      });
});
var connectionString = ConfigurationExtensions.GetConnectionString(appConfiguration, "DefaultConnection");
services.AddDbContext<HardCodeDbContext>(options => options.UseNpgsql(connectionString));
//services.AddDbContext<HardCodeDbContext>(options => options.UseSqlServer(connectionString));

services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();
