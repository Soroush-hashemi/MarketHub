using Shared.Domain.Bases;

namespace Shared.Domain.Exceptions;
public class UserNotFoundException : BaseDomainException
{
    public UserNotFoundException()
    {

    }

    public static void Check()
    {
        throw new NotImplementedException("user not exist");
    }
}