using ApiMarketHub.Domain.OrderAggregate;
using ApiMarketHub.Infrastructure.Persistence.Command;
using ApiMarketHub.Infrastructure.Persistence.Query;
using ApiMarketHub.Query.Orders.DTOs;
using Dapper;

namespace ApiMarketHub.Query.Orders;
internal static class OrderMapper
{
    public static OrderDto Map(this Order order)
    {
        return new OrderDto()
        {
            CreationDate = order.CreationDate,
            Id = order.Id,
            Status = order.Status,
            Address = order.Address,
            Discount = order.Discount,
            Items = new(),
            LastUpdate = order.LastUpdate,
            ShippingMethod = order.ShippingMethod,
            UserFullName = "",
            UserId = order.UserId,
        };
    }

    public static async Task<List<OrderItemDto>> GetOrderItems(this OrderDto orderDto, DapperContext dapperContext)
    {
        var connection = dapperContext.CreateConnection();
        var sql = $@"SELECT * o.Id , s.StoreName , o.OrderId,o.InventoryId,o.Count,o.price, 
                        p.Title as ProductTitle , p.Slug as ProductSlug,p.ImageName as ProductImageName
                    FROM {dapperContext.OrderItems} o
                    Inner Join {dapperContext.Inventories} i on o.InventoryId=i.Id
                    Inner Join {dapperContext.Products} p on i.ProductId=p.Id
                    Inner Join {dapperContext.Sellers} s on i.SellerId=s.Id
                    where o.OrderId=@orderId";

        var result = await connection.QueryAsync<OrderItemDto>(sql, new {orderId = orderDto.Id});
        return result.ToList();
    }

    public static OrderFilterDataDto MapFilterData(this Order order,MarketHubContext context)
    {
        var userFullName = context.Users.Where(r => r.Id == order.UserId).Select(u => $"{u.Name} {u.Family}").First();

        return new OrderFilterDataDto()
        {
            Status = order.Status,
            Id = order.Id,
            CreationDate = order.CreationDate,
            City = order.Address?.City,
            ShippingType = order.ShippingMethod?.ShippingType,
            State = order.Address?.State,
            TotalItemCount = order.ItemCount,
            TotalPrice = order.TotalPrice,
            UserFullName = userFullName,
            UserId = order.UserId
        };

    }
}