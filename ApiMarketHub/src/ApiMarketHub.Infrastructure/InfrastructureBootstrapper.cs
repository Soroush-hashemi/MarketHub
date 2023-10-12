using ApiMarketHub.Domain.CategoryAggregate.Repository;
using ApiMarketHub.Domain.CommentAggregate.Repository;
using ApiMarketHub.Domain.OrderAggregate.Repository;
using ApiMarketHub.Domain.ProductAggregate.Repository;
using ApiMarketHub.Domain.RoleAggregate.Repository;
using ApiMarketHub.Domain.SellerAggregate.Repository;
using ApiMarketHub.Domain.SideEntities.Repository;
using ApiMarketHub.Domain.UserAggregate.Repository;
using ApiMarketHub.Infrastructure.Persistence.Command;
using ApiMarketHub.Infrastructure.Persistence.Query;
using ApiMarketHub.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ApiMarketHub.Infrastructure;
public static class InfrastructureBootstrapper
{
    public static void Init(IServiceCollection services, string connectionString)
    {

        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<IOrderRepository, OrderRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IRoleRepository, RoleRepository>();
        services.AddTransient<ISellerRepository, SellerRepository>();
        services.AddTransient<IPosterRepository, PosterRepository>();
        services.AddTransient<ISliderRepository, SliderRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<ICommentRepository, CommentRepository>();
        services.AddTransient<IShippingMethodRepository, ShippingMethodRepository>();

        services.AddTransient(_ => new DapperContext(connectionString));
        services.AddDbContext<MarketHubContext>(option =>
        {
            option.UseSqlServer(connectionString);
        });
    }
}