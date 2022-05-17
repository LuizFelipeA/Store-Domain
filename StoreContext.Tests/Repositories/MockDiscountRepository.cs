using System;
using StoreContext.Domain.Entities;
using StoreContext.Domain.Repositories;

namespace StoreContext.Tests.Repositories;

public class MockDiscountRepository : IDiscountRepository
{
    public Discount? Get(string discountcode)
    {
        if(discountcode == "12345678")
            return new Discount(10, DateTime.Now.AddDays(5));
        
        if(discountcode == "11111111")
            return new Discount(10, DateTime.Now.AddDays(-5));

        return null;
    }
}