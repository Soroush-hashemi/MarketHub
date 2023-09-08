using Shared.Domain.Bases;
using Shared.Domain.Exceptions;

namespace ApiMarketHub.Domain.ProductAggregate;
public class ProductImage : BaseEntity
{
    public ProductImage(string imageName, int sequence)
    {
        NullOrEmptyException.CheckString(imageName, nameof(imageName));
        ImageName = imageName;
        Sequence = sequence;
    }

    public long ProductId { get; internal set; }
    public string ImageName { get; private set; }
    public int Sequence { get; private set; }
}