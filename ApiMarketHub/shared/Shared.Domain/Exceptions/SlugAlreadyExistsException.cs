using Shared.Domain.Bases;

namespace Shared.Domain.Exceptions;
public class SlugAlreadyExistsException : BaseDomainException
{
    public SlugAlreadyExistsException() : base("Slug Exists")
    {
    }

    public SlugAlreadyExistsException(string message) : base(message)
    {
    }
}
