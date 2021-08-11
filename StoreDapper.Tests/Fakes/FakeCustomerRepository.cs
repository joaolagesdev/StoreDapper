using System;
using System.Collections.Generic;
using StoreDapper.Domain.StoreContext.Entities;
using StoreDapper.Domain.StoreContext.Queries;
using StoreDapper.Domain.StoreContext.Repositories;

namespace StoreDapper.Tests.Fakes
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public bool CheckDocument(string document)
        {
            return false;
        }

        public bool CheckEmail(string email)
        {
            return false;
        }

    public IEnumerable<ListCustomerQueryResult> Get()
    {
      throw new NotImplementedException();
    }

    public GetCustomerQueryResult Get(Guid id)
    {
      throw new NotImplementedException();
    }

    public CustomerOrdersCountResult GetCustomerOrdersCount(string document)
    {
      throw new NotImplementedException();
    }

    public CustomerOrdersCountResult GetCustomerOrdersCountResult(string document)
        {
            throw new System.NotImplementedException();
        }

    public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
    {
      throw new NotImplementedException();
    }

    public void Save(Customer customer)
        {
            
        }
    }
}