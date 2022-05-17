using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreContext.Domain.Commands;

namespace StoreContext.Tests.Commands;

[TestClass]
public class CreateOrderCommandTests
{
    [TestMethod]
    [TestCategory("Commands")]
    public void ReturnFalseWhenCommandIsNotValid()
    {
        var command = new CreateOrderCommand();
        command.Customer = "";
        command.ZipCode = "123456780";
        command.Validate();

        Assert.AreEqual(command.IsValid, false);
    }

    [TestMethod]
    [TestCategory("Commands")]
    public void ReturnTrueWhenCommandIsValid()
    {
        var command = new CreateOrderCommand();
        command.Customer = "123456789000";
        command.ZipCode = "123456780";
        command.Validate();

        Assert.AreEqual(command.IsValid, true);
    }
}