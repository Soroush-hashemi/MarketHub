using Shared.Domain.Bases;

namespace Shared.Domain.Exception;

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