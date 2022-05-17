using StoreContext.Shared.Commands.Interfaces;
using StoreContext.Shared.Interfaces.Commands;

namespace StoreContext.Shared.Handlers.Interfaces;

public interface IHandler<T> where T : ICommand
{
    ICommandResult Handle(T command);
}
