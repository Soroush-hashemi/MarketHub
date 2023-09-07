using Shared.Domain.Bases;

namespace Shared.Domain.Exceptions;
public class InvalidDomainDataException : BaseDomainException
{
    public InvalidDomainDataException()
    {

    }
    public InvalidDomainDataException(string message) : base(message)
    {

    }
}