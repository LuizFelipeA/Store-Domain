using Flunt.Notifications;
using StoreContext.Domain.Commands;
using StoreContext.Domain.Entities;
using StoreContext.Domain.Repositories;
using StoreContext.Domain.Utils;
using StoreContext.Shared.Commands.Interfaces;
using StoreContext.Shared.Handlers.Interfaces;

namespace StoreContext.Domain.Handlers;

public class OrderHandler :
    Notifiable<Notification>,
    IHandler<CreateOrderCommand>
{
    private readonly ICustomerRepository _customerRepository;

    private readonly IDeliveryFeeRepository _deliveryFeeRepository;

    private readonly IDiscountRepository _discountRepository;

    private readonly IProductRepository _productRepository;

    private readonly IOrderRepository _orderRepository;

    public OrderHandler(
        ICustomerRepository customerRepository,
        IDeliveryFeeRepository deliveryFeeRepository,
        IDiscountRepository discountRepository,
        IProductRepository productRepository,
        IOrderRepository orderRepository)
    {
        _customerRepository = customerRepository;
        _deliveryFeeRepository = deliveryFeeRepository;
        _discountRepository = discountRepository;
        _productRepository = productRepository;
        _orderRepository = orderRepository;
    }

    public ICommandResult Handle(CreateOrderCommand command)
    {
        // Fail Fast Validation
        command.Validate();
        if(!command.IsValid)
            return new GenericCommandResult(
                success: false,
                message: "Invalid order",
                data: command.Notifications);

        var customer = _customerRepository.Get(command.Customer);

        var deliveryFee = _deliveryFeeRepository.Get(command.ZipCode);

        var discount = _discountRepository.Get(command.PromoCode);

        var products = _productRepository.Get(ExtractGuids.Extract(command.Items)).ToList();

        var order = new Order(customer, deliveryFee, discount);
        
        foreach (var item in command.Items)
        {
            var product = products.Where(product => product.Id == item.Product).FirstOrDefault();
            order.AddItem(product, item.Quantity);
        }

        AddNotifications(order.Notifications);

        if(!IsValid)
            return new GenericCommandResult(
                success: false,
                message: "Error proccessing your order.",
                data: Notifications);

        _orderRepository.Save(order);
        return new GenericCommandResult(
            success: true,
            message: $"Order {order.Number} generated succefully",
            data: order);
    }
}
