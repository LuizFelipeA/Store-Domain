using StoreContext.Shared.Entities;

namespace StoreContext.Domain.Entities;

public class Discount : Entity
{
    public Discount(decimal amount, DateTime expireDate)
    {
        Amount = amount;
        ExpireDate = expireDate;
    }

    public decimal Amount { get; }

    public DateTime ExpireDate { get; }

    public bool IsValid()
        => DateTime.Compare(DateTime.Now, ExpireDate) < 0;

    public decimal Value()
    {
        if(IsValid())
            return Amount;
        else
            return 0;
    }
}