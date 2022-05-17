using StoreContext.Domain.Repositories;

namespace StoreContext.Tests.Repositories;

public class MockDeliveryFeeRepository : IDeliveryFeeRepository
{
    public decimal Get(string zipCode)
    {
        return 10;
    }
}
