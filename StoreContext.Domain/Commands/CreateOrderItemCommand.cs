using Flunt.Notifications;
using Flunt.Validations;
using StoreContext.Shared.Interfaces.Commands;

namespace StoreContext.Domain.Commands;

public class CreateOrderItemCommand : Notifiable<Notification>, ICommand
{
    public CreateOrderItemCommand() { }

    public CreateOrderItemCommand(Guid product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }

    public Guid Product { get; set; }

    public int Quantity { get; set; }

    public void Validate()
    {
        AddNotifications(new Contract<CreateOrderItemCommand>()
            .Requires()
            .AreNotEquals(Product.ToString(), "00000000-0000-0000-0000-000000000000", "Product", "Invalid product")
            .IsGreaterThan(Product.ToString(), 32, "Product", "Invalid product")
            .IsGreaterThan(Quantity, 0, "Quantity", "Invalid quantity."));
    }
}
