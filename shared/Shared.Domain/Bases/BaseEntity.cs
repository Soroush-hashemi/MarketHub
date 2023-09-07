namespace Shared.Domain.Bases;

public class BaseEntity
{
    public long Id { get; private set; }
    public DateTime CreationDate { get; }

    public BaseEntity()
    {
        CreationDate = DateTime.Now;
    }
}