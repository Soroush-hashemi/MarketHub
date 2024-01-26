using ApiMarketHub.Config;
using Microsoft.EntityFrameworkCore;
using Shared.Application;
using Shared.Application.FileUtil.Interfaces;
using Shared.Application.FileUtil.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
// Add services to the container.
builder.Services.AddControllersWithViews();
    
services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
services.AddSwaggerGen();
var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (ConnectionString is null)
    throw new NullReferenceException("ConnectionString is null");
Bootstrapper.ConfigBootstrapper(services, ConnectionString);

ValidationBootstrapper.Init(services);
services.AddTransient<IFileService, FileService>();

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