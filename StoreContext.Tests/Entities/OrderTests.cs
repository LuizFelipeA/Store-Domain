using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreContext.Domain.Entities;
using StoreContext.Domain.Enums;

namespace StoreContext.Tests.Entities;

[TestClass]
public class OrderTests
{
    private readonly Customer _costumer = new Customer("Luiz", "lp@lp.com");

    private readonly Product _product = new Product("Product 1", 10, true);

    private readonly Discount _discount = new Discount(10, DateTime.Now.AddDays(5));


    [TestMethod]
    [TestCategory("Domain")]
    public void ShouldGenerateEightCharactersWhenNewOrderIsValid()
    {
        var order = new Order(_costumer, 9, _discount);

        Assert.AreEqual(8, order.Number.Length);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void ShouldReturnWaitingStatusPaymentForNewOrders()
    {
        var order = new Order(_costumer, 9, _discount);

        Assert.AreEqual(EOrderStatus.WaitingPayment, order.Status);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void ShouldReturnWaitingDeliveryStatusForPaidOrders()
    {
        var order = new Order(_costumer, 0, null);
        order.AddItem(_product, 1);
        order.Pay(10);

        Assert.AreEqual(EOrderStatus.WaitingDelivery, order.Status);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void ShouldReturnCanceledStatusForCanceledOrders()
    {
        var order = new Order(_costumer, 0, null);
        order.Cancel();

        Assert.AreEqual(EOrderStatus.Canceled, order.Status);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void ShouldReturnZeroForItemsWithoutProduct()
    {
        var order = new Order(_costumer, 0, null);
        order.AddItem(null, 3);

        Assert.AreEqual(0, order.Items.Count);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void ShouldReturnZeroForItemsWithQuantityOfZeroOrLess()
    {
        var order = new Order(_costumer, 0, null);
        order.AddItem(_product, 0);

        Assert.AreEqual(0, order.Items.Count);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void ShouldReturnFiftyForValidOrders()
    {
        var order = new Order(_costumer, 0, null);
        order.AddItem(_product, 5);

        Assert.AreEqual(50, order.Total());
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void ShouldReturnSixtyForOrderWithDeliveryFeeOfTen()
    {
        var order = new Order(_costumer, 10, null);
        order.AddItem(_product, 5);

        Assert.AreEqual(60, order.Total());
    }
}
