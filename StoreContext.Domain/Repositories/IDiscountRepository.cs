using StoreContext.Domain.Entities;

namespace StoreContext.Domain.Repositories;

public interface IDiscountRepository
{
    Discount Get(string discountcode);
}
