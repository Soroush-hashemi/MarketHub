namespace Shared.Domain.Bases;

public class BaseEntity 
{
    // تمام کلاس های انتیتی باید از این کلاس ارث‌بری بکنند بجز اگریگیت روت ها که از بیس خود ارث بری میکنند
    public long Id { get; set; }
    public DateTime CreationDate { get; }

    public BaseEntity()
    {
        CreationDate = DateTime.Now;
    }
}