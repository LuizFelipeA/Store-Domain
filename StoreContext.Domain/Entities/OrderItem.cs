using Flunt.Validations;
using StoreContext.Shared.Entities;

namespace StoreContext.Domain.Entities;

public class OrderItem : Entity
{
    public OrderItem(
        Product product,
        int quantity)
    {
        AddNotifications(new Contract<OrderItem>()
            .Requires()
            .IsNotNull(product, "Product", "Invalid Product.")
            .IsGreaterThan(quantity, 0, "Quantity", "Invalid Quantity"));

        Product = product;
        Price = Product != null ? product.Price : 0;
        Quantity = quantity;
    }

    public Product Product { get; }

    public decimal Price { get; }

    public int Quantity { get; }

    public decimal Total() => Price * Quantity;
}
