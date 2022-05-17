using System.Linq.Expressions;
using StoreContext.Domain.Entities;

namespace StoreContext.Domain.Queries;

public abstract class ProductQueries
{
    public static Expression<Func<Product, bool>> GetActiveProducts()
        => x => x.Active;

    public static Expression<Func<Product, bool>> GetInactiveProducts()
        => x => x.Active == false;
}
