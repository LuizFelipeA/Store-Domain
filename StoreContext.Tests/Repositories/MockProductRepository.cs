using System;
using System.Collections.Generic;
using StoreContext.Domain.Entities;
using StoreContext.Domain.Repositories;

namespace StoreContext.Tests.Repositories;

public class MockProductRepository : IProductRepository
{
    public IEnumerable<Product> Get(IEnumerable<Guid> ids)
    {
        IList<Product> products = new List<Product>();
        products.Add(new Product("Product 01", 10, true));
        products.Add(new Product("Product 02", 10, true));
        products.Add(new Product("Product 03", 10, true));
        products.Add(new Product("Product 04", 10, true));
        products.Add(new Product("Product 05", 10, true));

        return products;
    }
}
