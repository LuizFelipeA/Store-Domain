using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreContext.Domain.Commands;

namespace StoreContext.Tests.Commands;

[TestClass]
public class CreateOrderItemCommandTests
{
    [TestMethod]
    [TestCategory("Commands")]
    public void ShouldReturnFalseWhenProductIsNotValid()
    {
        var orderItem = new CreateOrderItemCommand(Guid.Empty, 10);
        orderItem.Validate();

        Assert.AreEqual(false, orderItem.IsValid);
    }

    [TestMethod]
    [TestCategory("Commands")]
    public void ShouldReturnFalseWhenQuantityIsNotValid()
    {
        var orderItem = new CreateOrderItemCommand(Guid.NewGuid(), 0);
        orderItem.Validate();

        Assert.AreEqual(false, orderItem.IsValid);
    }

    [TestMethod]
    [TestCategory("Commands")]
    public void ShouldReturnTrueWhenProductIsValid()
    {
        var orderItem = new CreateOrderItemCommand(Guid.NewGuid(), 10);
        orderItem.Validate();

        Assert.AreEqual(true, orderItem.IsValid);
    }
}
