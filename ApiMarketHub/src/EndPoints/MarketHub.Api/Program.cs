using AngleSharp;
using ApiMarketHub.Config;
using ApiMarketHub.Infrastructure.Persistence.Command;
using Microsoft.EntityFrameworkCore;
using Shared.Application;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
// Add services to the container.

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
services.AddSwaggerGen();

var app = builder.Build();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (connectionString != null)
    services.ConfigBootstrapper(connectionString);

ValidationBootstrapper.Init(services);

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