using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreContext.Domain.Entities;
using StoreContext.Domain.Queries;

namespace StoreContext.Tests.Queries;

[TestClass]
public class ProductQueriesTests
{
    private IList<Product> _products;

    public ProductQueriesTests()
    {
        _products = new List<Product>();
        _products.Add(new Product("Product 01", 10, true));
        _products.Add(new Product("Product 02", 20, true));
        _products.Add(new Product("Product 03", 30, true));
        _products.Add(new Product("Product 04", 40, false));
        _products.Add(new Product("Product 05", 50, false));
    }

    [TestMethod]
    [TestCategory("Queries")]
    public void ShouldReturnThreeWhenQueryActiveProducts()
    {
        var queryResult = _products.AsQueryable().Where(ProductQueries.GetActiveProducts());

        var count = queryResult.Count();

        Assert.AreEqual(3, queryResult.Count());
    }

    [TestMethod]
    [TestCategory("Queries")]
    public void ShouldReturnTwoWhenQueryInactiveProducts()
    {
        var queryResult = _products.AsQueryable().Where(ProductQueries.GetInactiveProducts());

        Assert.AreEqual(2, queryResult.Count());
    }
}
