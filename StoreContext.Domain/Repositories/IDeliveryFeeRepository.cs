namespace StoreContext.Domain.Repositories;

public interface IDeliveryFeeRepository
{
     decimal Get(string zipCode);
}
