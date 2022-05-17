using StoreContext.Domain.Entities;

namespace StoreContext.Domain.Repositories;

public interface IOrderRepository
{
    void Save(Order order);
}
