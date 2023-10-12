using ApiMarketHub.Config;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
// Add services to the container.
builder.Services.AddControllersWithViews();

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
services.AddSwaggerGen();

var app = builder.Build();

Bootstrapper.ConfigBootstrapper(services, builder.Configuration.GetConnectionString("DefaultConnection"));

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