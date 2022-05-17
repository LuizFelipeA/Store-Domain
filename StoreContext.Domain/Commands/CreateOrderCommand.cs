using Flunt.Notifications;
using Flunt.Validations;
using StoreContext.Shared.Interfaces.Commands;

namespace StoreContext.Domain.Commands;

public class CreateOrderCommand : Notifiable<Notification>, ICommand
{
    public CreateOrderCommand()
    {
        Items = new List<CreateOrderItemCommand>();
    }

    public CreateOrderCommand(
        string customer,
        string zipCode,
        string promoCode,
        IList<CreateOrderItemCommand> items)
    {
        Customer = customer;
        ZipCode = zipCode;
        PromoCode = promoCode;
        Items = items;
    }

    public string Customer { get; set; }

    public string ZipCode { get; set; }

    public string PromoCode { get; set; }

    public IList<CreateOrderItemCommand> Items { get; set; }

    public void Validate()
    {
        AddNotifications(new Contract<CreateOrderCommand>()
            .Requires()
            .IsGreaterThan(Customer, 11, "Customer", "Invalid customer.")
            .IsGreaterThan(ZipCode, 8, "ZipCode", "Invalid ZipCode"));
    }
}
