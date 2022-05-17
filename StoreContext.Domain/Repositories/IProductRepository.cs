using StoreContext.Domain.Entities;

namespace StoreContext.Domain.Repositories;

public interface IProductRepository
{
    IEnumerable<Product> Get(IEnumerable<Guid> ids);
}
