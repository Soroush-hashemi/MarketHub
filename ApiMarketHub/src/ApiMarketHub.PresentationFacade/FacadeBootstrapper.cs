using ApiMarketHub.PresentationFacade.Categories;
using ApiMarketHub.PresentationFacade.Comments;
using ApiMarketHub.PresentationFacade.Orders;
using ApiMarketHub.PresentationFacade.Products;
using ApiMarketHub.PresentationFacade.Roles;
using ApiMarketHub.PresentationFacade.Sellers.Inventories;
using ApiMarketHub.PresentationFacade.Sellers;
using ApiMarketHub.PresentationFacade.SideEntities.ShippingMethods;
using ApiMarketHub.PresentationFacade.SideEntities.Slider;
using ApiMarketHub.PresentationFacade.Users.Addresses;
using ApiMarketHub.PresentationFacade.Users;
using Microsoft.Extensions.DependencyInjection;
using ApiMarketHub.PresentationFacade.SideEntities.Poster;

namespace ApiMarketHub.PresentationFacade;
public static class FacadeBootstrapper
{
    public static void InitFacadeDependency(IServiceCollection services)
    {
        services.AddTransient<ICategoryFacade, CategoryFacade>();
        services.AddTransient<ICommentFacade, CommentFacade>();
        services.AddTransient<IOrderFacade, OrderFacade>();
        services.AddTransient<IProductFacade, ProductFacade>();
        services.AddTransient<IRoleFacade, RoleFacade>();
        services.AddTransient<ISellerFacade, SellerFacade>();
        services.AddTransient<IPosterFacade, PosterFacade>();
        services.AddTransient<ISliderFacade, SliderFacade>();
        services.AddTransient<ISellerInventoryFacade, SellerInventoryFacade>();
        services.AddTransient<IShippingMethodFacade, ShippingMethodFacade>();
        services.AddTransient<IUserFacade, UserFacade>();
        services.AddTransient<IUserAddressFacade, UserAddressFacade>();
    }
}