using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreContext.Domain.Entities;
using StoreContext.Domain.Enums;

namespace StoreContext.Tests.Entities;

[TestClass]
public class DiscountTests
{
    private readonly Customer _costumer = new Customer("Luiz", "lp@lp.com");

    private readonly Product _product = new Product("Product 1", 10, true);

    private readonly Discount _discount = new Discount(10, DateTime.Now.AddDays(5));

    [TestMethod]
    [TestCategory("Domain")]
    public void ShouldReturnSixtyForExpireDiscount()
    {
        var expireDiscount = new Discount(10, DateTime.Now.AddDays(-5));
        var order = new Order(_costumer, 0, expireDiscount);
        order.AddItem(_product, 6);

        Assert.AreEqual(60, order.Total());
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void ShouldReturnSixtyForInvalidDiscount()
    {
        var order = new Order(_costumer, 0, null);
        order.AddItem(_product, 6);

        Assert.AreEqual(60, order.Total());
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void ShouldReturnFiftyForOrderWithDiscountOfTen()
    {
        var order = new Order(_costumer, 0, _discount);
        order.AddItem(_product, 6);

        Assert.AreEqual(50, order.Total());
    }
}
