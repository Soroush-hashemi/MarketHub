using Shared.Domain.Bases;
using Shared.Domain.Exceptions;

namespace ApiMarketHub.Domain.SideEntities;
public class ShippingMethod : BaseEntity
{
    public ShippingMethod(int cost, string title)
    {
        NullOrEmptyException.CheckString(title, nameof(title));
        Cost = cost;
        Title = title;
    }

    public void Edit(int cost, string title)
    {
        NullOrEmptyException.CheckString(title, nameof(title));
        Cost = cost;
        Title = title;
    }

    public string Title { get; private set; }
    public int Cost { get; private set; }
}