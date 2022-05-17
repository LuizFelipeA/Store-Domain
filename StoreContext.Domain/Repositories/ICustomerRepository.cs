using StoreContext.Domain.Entities;

namespace StoreContext.Domain.Repositories;

public interface ICustomerRepository
{
    Customer Get(string document);
}
