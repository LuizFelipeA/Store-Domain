using StoreContext.Shared.Commands.Interfaces;

namespace StoreContext.Domain.Commands;

public class GenericCommandResult : ICommandResult
{
    public GenericCommandResult(
        bool success,
        string message,
        object data)
    {
        Success = success;
        Message = message;
        Data = data;
    }

    public bool Success { get; }

    public string Message { get; }

    public object Data { get; }
}
