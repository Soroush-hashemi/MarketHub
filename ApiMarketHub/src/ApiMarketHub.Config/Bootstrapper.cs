using ApiMarketHub.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Shared.Application.FileUtil;
using ApiMarketHub.Domain.SellerAggregate.Service;
using ApiMarketHub.Domain.UserAggregate.Service;
using ApiMarketHub.Domain.CategoryAggregate.Service;
using ApiMarketHub.Domain.ProductAggregate.Service;
using ApiMarketHub.Application.Products;
using ApiMarketHub.Application.Categories;
using ApiMarketHub.Application.Users;
using ApiMarketHub.Application.Sellers;
using MediatR;
using ApiMarketHub.Query.Categories.GetById;
using FluentValidation;
using ApiMarketHub.Application.Roles.Create;
using Shared.Application;
using ApiMarketHub.PresentationFacade;
using System.Reflection;

namespace ApiMarketHub.Config;
public static class Bootstrapper
{
    public static void ConfigBootstrapper(this IServiceCollection services, string connectionString)
    {
        InfrastructureBootstrapper.Init(services, connectionString);

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Directories).Assembly));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetCategoryByIdQuery).Assembly));

        services.AddTransient<IProductDomainService, ProductDomainService>();
        services.AddTransient<IUserDomainService, UserDomainService>();
        services.AddTransient<ICategoryDomainService, CategoryDomainService>();
        services.AddTransient<ISellerDomainService, SellerDomainService>();

        ValidationBootstrapper.Init(services);
        
        services.AddValidatorsFromAssembly(typeof(CreateRoleCommandValidator).Assembly);

        FacadeBootstrapper.InitFacadeDependency(services);
    }
}