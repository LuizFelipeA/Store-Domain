using StoreContext.Domain.Entities;
using StoreContext.Domain.Repositories;

namespace StoreContext.Tests.Repositories;

public class MockOrderRepository : IOrderRepository
{
    public void Save(Order order) { }
}