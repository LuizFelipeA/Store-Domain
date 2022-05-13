using StoreContext.Shared.Entities;

namespace StoreContext.Domain.Entities;

public class Customer : Entity
{
    public Customer(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public string Name { get; }

    public string Email { get; }
}
