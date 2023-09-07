using Shared.Domain.Bases;

namespace Shared.Domain.Exception;
public class InvalidDomainDataException : BaseDomainException
{
    public InvalidDomainDataException()
    {

    }
    public InvalidDomainDataException(string message) : base(message)
    {

    }
}