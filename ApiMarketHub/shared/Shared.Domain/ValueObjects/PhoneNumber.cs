using Shared.Domain.Bases;
using Shared.Domain.Exceptions;
using Shared.Domain.Tools;

namespace Shared.Domain.ValueObjects;
public class PhoneNumber : BaseValueObject
{
    public string Value { get; private set; }

    public PhoneNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.IsText() || value.Length is < 11 or > 11)
            throw new InvalidDomainDataException("شماره تلفن نامعتبر است");
        Value = value;
    }
}