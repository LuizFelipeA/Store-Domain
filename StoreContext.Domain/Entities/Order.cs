
using Flunt.Validations;
using StoreContext.Domain.Enums;
using StoreContext.Shared.Entities;

namespace StoreContext.Domain.Entities;

public class Order : Entity
{
    private IList<OrderItem> _items;

    public Order(
        Customer customer,
        decimal deliveryFee,
        Discount discount)
    {
        AddNotifications(new Contract<Order>()
            .Requires()
            .IsNotNull(customer, "Customer", "Invalid Customer."));

        Customer = customer;
        Date = DateTime.Now;
        Number = Guid.NewGuid().ToString().Substring(0, 8);
        _items = new List<OrderItem>();
        DeliveryFee = deliveryFee;
        Discount = discount;
        Status = EOrderStatus.WaitingPayment;
    }

    public Customer Customer { get; }

    public DateTime Date { get; }

    public string Number { get; }

    public IList<OrderItem> Items { get { return _items.ToList(); } }

    public decimal DeliveryFee { get; }

    public Discount Discount { get; }

    public EOrderStatus Status { get; private set; }

    public void AddItem(Product product, int quantity)
    {
        var item = new OrderItem(product, quantity);

        if(item.IsValid)
            _items.Add(new OrderItem(product, quantity));
    }

    public decimal Total()
    {
        decimal total = 0;
        foreach (var item in Items)
        {
            total += item.Total();
        }

        total += DeliveryFee;
        total -= Discount != null ? Discount.Value() : 0;

        return total;
    }

    public void Pay(decimal amount)
    {
        if(amount == Total())
            Status = EOrderStatus.WaitingDelivery;
    }

    public void Cancel()
    {
        Status = EOrderStatus.Canceled;
    }
}
