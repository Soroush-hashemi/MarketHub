using ApiMarketHub.Query.Orders.DTOs;
using Shared.Query;

namespace ApiMarketHub.Query.Orders.GetByFilter;
public class GetOrdersByFilterQuery : QueryFilter<OrderFilterResult, OrderFilterParams>
{
    public GetOrdersByFilterQuery(OrderFilterParams orderFilter) : base(orderFilter)
    {
            
    }
}