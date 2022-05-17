using StoreContext.Domain.Entities;
using StoreContext.Domain.Repositories;

namespace StoreContext.Tests.Repositories;

public class MockCustomerRepository : ICustomerRepository
{
   public Customer? Get(string document) 
   {
       if(document == "12345678900")
            return new Customer("Bruce Wayne", "batman@lp.com");

        return null;
   }
}
