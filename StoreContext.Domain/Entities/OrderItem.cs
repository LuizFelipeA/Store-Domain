using StoreContext.Shared.Entities;

namespace StoreContext.Domain.Entities;

public class OrderItem : Entity
{
    public OrderItem(
        Product product,
        int quantity)
    {
        Product = product;
        Price = Product != null ? product.Price : 0;
        Quantity = quantity;
    }

    public Product Product { get; }

    public decimal Price { get; }

    public int Quantity { get; }

    public decimal Total() => Price * Quantity;
}
