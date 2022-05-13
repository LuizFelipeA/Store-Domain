
using Flunt.Notifications;

namespace StoreContext.Shared.Entities;

public class Entity : Notifiable<Notification>
{
    public Entity()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; }
}
