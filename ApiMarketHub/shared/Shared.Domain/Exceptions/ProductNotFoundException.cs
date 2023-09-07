using Shared.Domain.Bases;

namespace Shared.Domain.Exceptions;

public class ProductNotFoundException : BaseDomainException
{
    public ProductNotFoundException()
    {

    }

    public static void Check()
    {
        throw new NotImplementedException("product not exist");
    }
}