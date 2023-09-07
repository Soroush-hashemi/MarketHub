using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Domain.Bases;

public class AggregateRoot : BaseEntity
{
    // این فیلد برای نگه‌داری ایونت های انتیتی که در طول زمان رخ می‌دهند، مورد استفاده قرار می‌گرد
    private readonly List<BaseDomainEvent> _domainEvents = new List<BaseDomainEvent>();
    [NotMapped] //این ویژگی به ای اف کور اطلاع میدهد که در  پایگاه‌داده مپ نشود

    // با استفاده از کد پایین 
    // به کلاس دامین ایونت بالا کلاس دسترسی پیدا می کنیم بدون اینکه امکان تغییر مقدار آن را داشته باشیم 
    public List<BaseDomainEvent> DomainEvents => _domainEvents;

    public void AddDomainEvent(BaseDomainEvent EventItem)
    {
        _domainEvents.Add(EventItem);
    }

    public void RemoveDomainEvent(BaseDomainEvent EventItem)
    {
        _domainEvents.Remove(EventItem);
    }
}
