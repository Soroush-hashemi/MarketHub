using Shared.Domain.Bases;
using Shared.Domain.Exceptions;

namespace ApiMarketHub.Domain.ProductAggregate;
public class ProductSpecification : BaseEntity
{
    public long ProductId { get; internal set; }
    public string Key { get; private set; }
    public string Value { get; private set; }
    public ProductSpecification(string key, string value)
    {
        NullOrEmptyException.CheckString(key, nameof(key));
        NullOrEmptyException.CheckString(value, nameof(value));

        Key = key;
        Value = value;
    }
}