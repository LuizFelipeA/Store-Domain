using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreContext.Domain.Commands;
using StoreContext.Domain.Handlers;
using StoreContext.Domain.Repositories;
using StoreContext.Tests.Repositories;

namespace StoreContext.Tests.Handlers;

[TestClass]
public class OrderHandlerTests
{
    private readonly ICustomerRepository _customerRepository;

    private readonly IDeliveryFeeRepository _deliveryRepository;

    private readonly IDiscountRepository _discountRepository;

    private readonly IOrderRepository _orderRepository;

    private readonly IProductRepository _productRepository;

    public OrderHandlerTests()
    {
        _customerRepository = new MockCustomerRepository();
        _deliveryRepository = new MockDeliveryFeeRepository();
        _discountRepository = new MockDiscountRepository();
        _orderRepository = new MockOrderRepository();
        _productRepository = new MockProductRepository();
    }

    [TestMethod]
    [TestCategory("Handlers")]
    public void ShouldReturnInvalidOrderWhenCustomerDoesNotExist()
    {
        var command = new CreateOrderCommand();
        command.Customer = "12387878899898989898";
        command.ZipCode = "123456780";
        command.PromoCode = "12345678";
        command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
        command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));

        var handler = new OrderHandler(
            _customerRepository,
            _deliveryRepository,
            _discountRepository,
            _productRepository,
            _orderRepository);

        handler.Handle(command);

        Assert.AreEqual(false, handler.IsValid);
    }

    [TestMethod]
    [TestCategory("Handlers")]
    public void ShouldReturnValidOrderWhenZipCodeIsInvalid()
    {
        var command = new CreateOrderCommand();
        command.Customer = "12345678900";
        command.ZipCode = "123";
        command.PromoCode = "12345678";
        command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
        command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));

        var handler = new OrderHandler(
            _customerRepository,
            _deliveryRepository,
            _discountRepository,
            _productRepository,
            _orderRepository);

        handler.Handle(command);

        Assert.AreEqual(true, handler.IsValid);
    }

    [TestMethod]
    [TestCategory("Handlers")]
    public void ShouldReturnValidOrderWhenPromoCodeDoesNotExist()
    {
        var command = new CreateOrderCommand();
        command.Customer = "12345678900";
        command.ZipCode = "123";
        command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
        command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));

        var handler = new OrderHandler(
            _customerRepository,
            _deliveryRepository,
            _discountRepository,
            _productRepository,
            _orderRepository);

        handler.Handle(command);

        Assert.AreEqual(true, handler.IsValid);
    }

    [TestMethod]
    [TestCategory("Handlers")]
    public void ShouldReturnInvalidOrderWhenThereIsNoItems()
    {
        var command = new CreateOrderCommand();
        command.Customer = "12345678900000";
        command.ZipCode = "1231313231313";

        var handler = new OrderHandler(
            _customerRepository,
            _deliveryRepository,
            _discountRepository,
            _productRepository,
            _orderRepository);

        handler.Handle(command);

        Assert.AreEqual(false, handler.IsValid);
    }

    [TestMethod]
    [TestCategory("Handlers")]
    public void ShouldReturnInvalidOrderWhenCommandIsNotValid()
    {
        var command = new CreateOrderCommand();
        command.Customer = "";
        command.ZipCode = "123456780";
        command.Validate();
        
        Assert.AreEqual(command.IsValid, false);
    }

    [TestMethod]
    [TestCategory("Handlers")]
    public void ShouldReturnValidOrderWhenCommandIsValid()
    {
        var command = new CreateOrderCommand();
        command.Customer = "12345678900";
        command.ZipCode = "123456780";
        command.PromoCode = "12345678";
        command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
        command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));

        var handler = new OrderHandler(
            _customerRepository,
            _deliveryRepository,
            _discountRepository,
            _productRepository,
            _orderRepository);

        handler.Handle(command);
        Assert.AreEqual(true, handler.IsValid);
    }
}
